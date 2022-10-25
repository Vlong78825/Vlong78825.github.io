import { NgModule } from '@angular/core';
import { WelcomeRoutingModule } from './welcome-routing.module';
import { CommonModule } from '@angular/common'
import { WelcomeComponent } from './welcome.component';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FormsModule } from '@angular/forms';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzIconModule } from 'ng-zorro-antd/icon';
@NgModule({
  imports: [WelcomeRoutingModule,
    NzTableModule,
    NzDividerModule,
    CommonModule,
    NzModalModule,
    NzInputModule,
    FormsModule,
    NzDropDownModule
    ,NzIconModule
    
  

  
  ],
  declarations: [WelcomeComponent],
  exports: [WelcomeComponent]
})
export class WelcomeModule {
 
 }
