import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';

import { HomeComponent } from './components/home/home.component';
import { AvailableInventoryListComponent } from './components/availableInventory/availableInventory.component';
import { AddHardwareListComponent } from './components/addhardwarelist/addhardwarelist.component';
import { AddUserComponent } from './components/adduser/adduser.component';
import { ViewUserDetailComponent } from './components/viewUserDetail/viewUserDetail.component';
import { InventoryassigntoempcomponentList } from './components/inventoryAssignToEmp/inventoryassigntoemp.component';
import { InventorysummarycomponentList } from './components/inventorySummary/inventorysummary.component';

import { LoginComponent } from './components/login/login.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        AvailableInventoryListComponent, 
        AddHardwareListComponent,           
        AddUserComponent,
        ViewUserDetailComponent,
        InventoryassigntoempcomponentList,
        InventorysummarycomponentList,

        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'availableInventory', component: AvailableInventoryListComponent },
            { path: 'addhardwarelist', component: AddHardwareListComponent },                    
            { path: 'adduser', component: AddUserComponent },
            { path: 'viewUserDetail/:id', component: ViewUserDetailComponent },
            { path: 'inventoryassigntoemp', component: InventoryassigntoempcomponentList },
            { path: 'inventorysummary', component: InventorysummarycomponentList },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'login' }
        ])
    ]
})
export class AppModuleShared {
}
