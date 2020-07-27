using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.N11
{
    public class CategoryHelper
    {
        CategoryService.CategoryServicePortService categoryService = null;
        private string _appKey, _appSecret = string.Empty;

        public CategoryHelper(string appKey, string appSecret)
        {
            categoryService = new CategoryService.CategoryServicePortService();
            _appKey = appKey;
            _appSecret = appSecret;

        }

        public CategoryService.Authentication Authentication {
            get {
                return new CategoryService.Authentication()
                {
                    appKey = _appKey,
                    appSecret = _appSecret
                };
            }
        }

        public N11Category[] GetTopCategory()
        {
            var topCategory = categoryService.GetTopLevelCategories(new CategoryService.GetTopLevelCategoriesRequest()
            {
                auth = Authentication
            });
            if (topCategory.result.status != "success")
            {
                throw new Exception(topCategory.result.errorMessage);
            }
            return topCategory.categoryList.Select(s => new N11Category()
            {
                Id = s.id,
                Name = s.name

            }).ToArray();

        }

        public N11Category GetParentCategory(int categoryId)
        {

            var topCategory = categoryService.GetParentCategory(new CategoryService.GetParentCategoryRequest()
            {
                auth = Authentication,
                categoryId = categoryId
            });
            if (topCategory.result.status != "success")
            {
                throw new Exception(topCategory.result.errorMessage);
            }
            return new N11Category()
            {
                Id = topCategory.category.id,
                Name = topCategory.category.name
            };
        }
        public N11Category[] GetSubCategories(long categoryId)
        {
            var topCategory = categoryService.GetSubCategories(new CategoryService.GetSubCategoriesRequest()
            {
                auth = Authentication,
                categoryId = categoryId
            });
            if (topCategory.result.status != "success")
            {
                throw new Exception(topCategory.result.errorMessage);
            }
            try
            {
                if (topCategory.category[0].subCategoryList == null)
                    return new N11Category[0];
                return topCategory.category[0].subCategoryList.Select(s => new N11Category()
                {
                    Id = s.id,
                    Name = s.name,
                    ParentId = categoryId
                }).ToArray();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public N11CategoryAttribute[] GetCategoryAttributes(int categoryId)
        {

            var categoryAttributes = categoryService.GetCategoryAttributes(new CategoryService.GetCategoryAttributesRequest()
            {
                auth = Authentication,
                categoryId = categoryId,
                pagingData = new CategoryService.RequestPagingData()
                {
                    currentPage = 1,
                    pageSize = 20
                }
            });

            var attributes = categoryAttributes.category.attributeList;

            return attributes.Select(s => new N11CategoryAttribute()
            {
                Id = s.id,
                Mandatory = s.mandatory,
                Multiselect = s.multipleSelect,
                Name = s.name,
                N11CategoryAttributes = s.valueList.Select(k => new N11CategoryAttributeValue()
                {
                    Id = k.id,
                    Name = k.name
                }).ToArray()
            }).ToArray();

        }



    }
}
