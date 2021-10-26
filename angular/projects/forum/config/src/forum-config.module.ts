import { ModuleWithProviders, NgModule } from '@angular/core';
import { FORUM_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ForumConfigModule {
  static forRoot(): ModuleWithProviders<ForumConfigModule> {
    return {
      ngModule: ForumConfigModule,
      providers: [FORUM_ROUTE_PROVIDERS],
    };
  }
}
