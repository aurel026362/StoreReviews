using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StoreReview.Core.Interfaces
{
    public interface IFileService
    {
		Task<string> UploadAsync(IFormFile imageFile);
		Task DeleteAsync(string path);
		Task<Stream> OpenReadAsync(string path);
	}
}
