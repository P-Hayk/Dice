import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DeskComponent } from "app/desk/desk.component";


const DeskRoutes: Routes = [
    {
        path: '',
        component: DeskComponent,
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(DeskRoutes)],
    exports: [RouterModule]
})

export class DeskRoutingModule { }