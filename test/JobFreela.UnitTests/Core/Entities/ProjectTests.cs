using JobFreela.Core.Entities;
using JobFreela.Core.Enums;

namespace JobFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome De Teste", "Descricao de Teste", 1, 2, 10000);

            Assert.Equal(ProjectStatus.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatus.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}
