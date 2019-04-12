import { Component, Inject } from '@angular/core';
import { AppComponent } from '../app/app.component';

import { Router } from '@angular/router';
import { sharedStylesheetJitUrl } from '@angular/compiler';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css' ]
})
export class HomeComponent {  
    constructor(private _http: Http, @Inject('BASE_URL') private baseUrl: string, private _appComp: AppComponent, private router: Router) {

        this._appComp.showMainNav();
        this.LoadAllUserName();
        this.getAssignHardwarebyUserId();
       
    }

    Modal = new PostIssueHardwareModel();
    userTypeList: userTypeModal[] = [];
    IssueHardwareList: IssueHardwareModal[] = [];
    ItemModel = new IssueHardwareModal();

    public id: number = 0;

    ngOnInit() {
        if (sessionStorage.length == 0) {
            this.router.navigate(['/login']);
        }
    }


    LoadAllUserName() {

        this._http.get(this.baseUrl + 'api/Users/GetUsersName').subscribe(result => {
            this.userTypeList = result.json() as userTypeModal[];
        });
    }


    getAssignHardwarebyUserId() { 
        this.id =this.Modal.userId;
        if (this.id == 0)
        {
            return;
        }
        else {
           
            this._http.get(this.baseUrl + 'api/IssueHardware/' + this.id).subscribe(result => {
                debugger;
                this.IssueHardwareList = result.json() as IssueHardwareModal[] ;

            });

        


        }      
    }


}
class userTypeModal {
    userId: number = 0;
    name: string = "";
}
class PostIssueHardwareModel {
    id: number = 0;
    userId: number = 0;
    hardwareTypeId = 0;
}

class IssueHardwareModal {   
    name: string = "";
    hardwareType: string = "";
    allocationDate: string = "";
}