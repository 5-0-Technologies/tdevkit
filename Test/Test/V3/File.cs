using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class File : Requests
    {
        [TestCategory("File")]
        [TestMethod]
        public async Task GetLogo_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "File error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/logo/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetLogo());
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetPlatformFile_ShouldReturn200()
        {
            var bytes = new byte[] { 1, 2, 3 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/name.bin").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetPlatformFile("name.bin");
            Assert.IsInstanceOfType(response, typeof(byte[]));
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetPlatformFileInfo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/info/name.bin").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new FileContract { Name = "name.bin" }));

            var response = await devkitConnector.GetPlatformFileInfo("name.bin");
            Assert.IsInstanceOfType(response, typeof(FileContract));
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetLogo_ShouldReturn200()
        {
            var bytes = new byte[] { 9 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/logo/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetLogo();
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetAreaImage_ShouldReturn200()
        {
            var guid = Guid.Parse("00000000-0000-0000-0000-000000000010");
            var bytes = new byte[] { 4 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/area-image/" + guid).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetAreaImage(guid);
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task PostAreaImage_ShouldReturn200()
        {
            var guid = Guid.Parse("00000000-0000-0000-0000-000000000010");
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/area-image/" + guid).UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostAreaImage(guid, new byte[] { 1 });
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerBundleInfo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-bundle-info/win").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new FileContract { Name = "win" }));

            var response = await devkitConnector.GetTviewerBundleInfo("win");
            Assert.IsInstanceOfType(response, typeof(FileContract));
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerBundleInfoBatch_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-bundle-info/win/batch").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new FileContract { Name = "win" } }));

            var response = await devkitConnector.GetTviewerBundleInfoBatch("win");
            Assert.IsInstanceOfType(response, typeof(FileContract[]));
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerBundle_ShouldReturn200()
        {
            var bytes = new byte[] { 5 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-bundle/win").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetTviewerBundle("win");
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task PostTviewerBundle_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-bundle/win").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostTviewerBundle("win", new byte[] { 1 });
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerThumbnail_ShouldReturn200()
        {
            var bytes = new byte[] { 6 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-thumbnail/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetTviewerThumbnail();
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerThumbnailInfo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-thumbnail-info/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new FileContract { Name = "thumb" }));

            var response = await devkitConnector.GetTviewerThumbnailInfo();
            Assert.IsInstanceOfType(response, typeof(FileContract));
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerThumbnailInfos_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-thumbnail-infos/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new FileContract { Name = "thumb" } }));

            var response = await devkitConnector.GetTviewerThumbnailInfos();
            Assert.IsInstanceOfType(response, typeof(FileContract[]));
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetTviewerThumbnailInfoBatch_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-thumbnail-info/batch").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new FileContract { Name = "thumb" } }));

            var response = await devkitConnector.GetTviewerThumbnailInfoBatch();
            Assert.IsInstanceOfType(response, typeof(FileContract[]));
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task PostTviewerBundleThumbnail_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tviewer-bundle-thumbnail").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostTviewerBundleThumbnail(new byte[] { 1 });
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task PostTmindMd_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/tmind-md/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostTmindMd(new { content = "x" });
        }

        [TestCategory("File")]
        [TestMethod]
        public async Task GetModeljobRawModel_ShouldReturn200()
        {
            const int Id = 7;
            var bytes = new byte[] { 7 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "file/modeljob-raw-model/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetModeljobRawModel(Id);
            CollectionAssert.AreEqual(bytes, response);
        }
    }
}
