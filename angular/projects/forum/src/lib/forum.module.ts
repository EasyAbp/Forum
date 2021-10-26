import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ForumComponent } from './components/forum.component';
import { ForumRoutingModule } from './forum-routing.module';

@NgModule({
  declarations: [ForumComponent],
  imports: [CoreModule, ThemeSharedModule, ForumRoutingModule],
  exports: [ForumComponent],
})
export class ForumModule {
  static forChild(): ModuleWithProviders<ForumModule> {
    return {
      ngModule: ForumModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ForumModule> {
    return new LazyModuleFactory(ForumModule.forChild());
  }
}
