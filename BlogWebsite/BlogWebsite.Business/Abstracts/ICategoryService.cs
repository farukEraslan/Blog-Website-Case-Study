﻿
namespace BlogWebsite.Business.Abstracts
{
    public interface ICategoryService
    {
        CategoryDTO GetById(Guid id);
    }
}
