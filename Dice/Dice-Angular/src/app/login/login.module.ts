import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login-routing.module';
import { ApiRequestService } from "app/shared/api.request.service";
import { PlayerRequestService } from "app/shared/player.request.service";


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        LoginRoutingModule,
        ReactiveFormsModule
    ],
    providers:[PlayerRequestService],
    declarations: [LoginComponent]
})

export class LoginModule { }