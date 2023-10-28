using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController:Controller
    {
        public static List<Product> list = new()
        {
            new(1,"p1","p1 desc",5,"https://picsum.photos/200/300?random=1"),
            new(2,"p2","p2 desc",50,"https://picsum.photos/200/300?random=1"),
            new(3,"p3","p3 desc",15,"https://picsum.photos/200/300?random=1"),
            new(4,"p4","p4 desc",25,"https://picsum.photos/200/300?random=1"),
        };


        public IActionResult Index()
        {
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            list.Add(product);

            return RedirectToAction("Index");
        }

        public IActionResult delete(int id)
        {
            var data = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(data);
            return RedirectToAction("Index");
        }

        public IActionResult GetData(int id)
        {
            var data = list.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        public IActionResult Update(int id)
        {
            var data = list.Where(x => x.Id == id).FirstOrDefault();

            int id1 = data.Id;
            string name = data.Name;
            string desc = data.Description;
            int price = data.Price;
            string link = data.ImgLink;
            //Product product = new Product(id1,name,desc,price,link);

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Product newProduct)
        {
            var olddata = list.FirstOrDefault(x => x.Id == newProduct.Id);
            olddata.Id = newProduct.Id;
            olddata.Name = newProduct.Name;
            olddata.Description = newProduct.Description;
            olddata.Price = newProduct.Price;
            olddata.ImgLink = newProduct.ImgLink;
            return RedirectToAction("Index");

        }
        public IActionResult Search(string id)
        {
            var data = list.Where(p=>p.Description.Contains(id)).ToList();

            return View(data);
        }

        public IActionResult SearchById(int id)
        {
            var data = list.Where(p => p.Id== id).FirstOrDefault();
            ViewBag.data = data;

            return View();
        }

    }
}
