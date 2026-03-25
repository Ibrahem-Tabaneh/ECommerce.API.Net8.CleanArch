using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.IService
{
    public interface IImageMangmentService
    {
        Task<List<string>> AddImageAsync(IEnumerable<(string FileName, Stream Content)> files, string src);

        Task DeleteImagesAsync(IEnumerable<string> imagePaths);

    }
}
