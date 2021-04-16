using MVC_eCom.Entities;
using MVC_eCom.Services;
using MVC_eCom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_eCom.Web.Controllers
{
    /// <summary>
    /// 分類
    /// </summary>
    public class CategoryController : Controller
    {
        /// <summary>
        /// 分類首頁
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 表格(分類)
        /// </summary>
        /// <param name="search">搜尋</param>
        /// <param name="pageNo">第幾頁</param>
        /// <returns></returns>
        public ActionResult CategoryTable(string search, int? pageNo)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();
            //搜尋
            model.SearchTerm = search;
            //若沒有選擇頁數的話，預設第一頁
            pageNo = pageNo.HasValue ? pageNo > 0 ? pageNo.Value : 1 : 1;
            //計算搜尋類別的總數
            var totalRecords = CategoriesService.Instance.GetCategoriesCount(model.SearchTerm);
            //撈出搜尋類別的第幾頁
            model.Categories = CategoriesService.Instance.GetCategories(search, pageNo.Value);

            if (model.Categories != null)
            {
                model.Pager = new Pager(totalRecords, pageNo, 3);
                return PartialView("CategoryTable", model);
            }
            else
            {
                return HttpNotFound();
            }

        }
        #region Creation

        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModel model = new NewCategoryViewModel();
            return PartialView(model);
        }
        /// <summary>
        /// 新增類別
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            //驗證資料是否正確
            if (ModelState.IsValid)
            {
                var newCategory = new Category();
                newCategory.Name = model.Name;
                newCategory.Description = model.Description;
                newCategory.ImageURL = model.ImageURL;
                newCategory.isFeatured = model.isFeatured;
                CategoriesService.Instance.SaveCategory(newCategory);
                return RedirectToAction("CategoryTable");
            }
            else
            {
                //錯誤的話回傳500 Internal Server Error：伺服器端錯誤
                return new HttpStatusCodeResult(500);
            }

        }

        #endregion
        #region Updation


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            var category = CategoriesService.Instance.GetCategory(ID);
            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            model.ImageURL = category.ImageURL;
            model.isFeatured = category.isFeatured;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = CategoriesService.Instance.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.Description = model.Description;
            existingCategory.ImageURL = model.ImageURL;
            existingCategory.isFeatured = model.isFeatured;
            CategoriesService.Instance.UpdateCategory(existingCategory);
            return RedirectToAction("CategoryTable");
        }
        #endregion
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CategoriesService.Instance.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }
        /// <summary>
        /// 取得所有類別
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMainCategories()
        {
            var categories = CategoriesService.Instance.GetAllCategories();
            return PartialView(categories);
        }
    }
}