using WebECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using WebECommerce.Repository;
namespace WebECommerce.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp = _loaiSp.GetAllLoaiSp().OrderBy(x=>x.Loai);
            return View(loaiSp);
        }
    }
}
