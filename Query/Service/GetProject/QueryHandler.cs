using MediatR;
using TestTask.Query.Common;
using Dapper;

namespace TestTask.Query.Service.GetProject
{
    internal class QueryHandler(IConnectionFactory connectionFactory) : IRequestHandler<Query, ViewModel>
    {
        public async Task<ViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = new ViewModel();

            var sql = @"
                SELECT
                [if].Id AS Id,
                [if].StartName AS FileName,
                [if].Directory AS Directory,
                [if].LocalName AS LocalName
                FROM InputFiles [if]
                WHERE [if].Directory = @Guid
            ";

            var connection = connectionFactory.GetConnection();
            var query = await connection.QueryMultipleAsync(sql, request);
            result.InputFile = query.ReadFirstOrDefault<ViewModel._InputFile>();

            var projectPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", result.InputFile.Directory);

            var inputFilePath = Path.Combine(projectPath, result.InputFile.LocalName);
            var fileInfo = new FileInfo(inputFilePath);
            result.InputFile.Size = fileInfo.Length;

            return result;
        }
    }
}
