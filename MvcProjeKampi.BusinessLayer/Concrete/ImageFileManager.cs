using MvcProjeKampi.BusinessLayer.Abstract;
using MvcProjeKampi.DataAccessLayer.Abstract;
using  MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public List<ImageFile> GetImageFile()
        {
            return _imageFileDal.List();
        }
    }
}
