﻿namespace DemoTuan6.ProductService.EntityFrameworkCore;

/* This class can be used as a base class for EF Core integration tests,
 * while ProductServiceRepositoryTests uses a different approach.
 */
public abstract class ProductServiceEntityFrameworkCoreTestBase : ProductServiceTestBase<ProductServiceEntityFrameworkCoreTestModule>
{

}
