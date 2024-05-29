﻿using Volo.Abp.Modularity;

namespace DemoTuan6.SaasService;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class SaasServiceDomainTestBase<TStartupModule> : SaasServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
