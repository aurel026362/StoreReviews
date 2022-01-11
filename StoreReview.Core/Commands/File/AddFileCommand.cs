using MediatR;
using StoreReview.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class AddFileCommand: IRequest<FileDto>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }

        public long Size { get; set; }
    }
}
