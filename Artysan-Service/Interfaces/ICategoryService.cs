﻿using Artysan_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Artysan_Service.Interfaces
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryViewModel>> GetAll();
	}
}
