﻿using Volo.Abp.Modularity;

namespace DemoTuan6.AdministrationService;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class AdministrationServiceApplicationTestBase<TStartupModule> : AdministrationServiceTestBase<TStartupModule>
 where TStartupModule : IAbpModule
{

}
