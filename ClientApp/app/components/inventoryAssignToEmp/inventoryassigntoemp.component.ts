import { Component, Inject, Class } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http } from '@angular/http';
import { AppComponent } from '../app/app.component';

@Component({
    selector: 'inventoryassigntoemp-page',
    templateUrl: './inventoryassigntoemp.component.html'
})
export class InventoryassigntoempcomponentList {

    IssueHardwareList: IssueHardwareModal[] = [];
    hardwareTypeList: hardwareTypeModal[] = [];
    userTypeList: userTypeModal[]=[];

    Modal = new PostIssueHardwareModel();

    buttonName: string = "Save";
    public id: number = 0;
    errorMessage: string = "";
    cpuParts: boolean = false;



    constructor(private _http: Http, @Inject('BASE_URL') private baseUrl: string, private _appComp: AppComponent, private router: Router) {     
        this.LoadData();
        this.LoadHardwareTypes();
        this.LoadAllUserName();

    }

    ngOnInit() {
        if (sessionStorage.length == 0) {
            this.router.navigate(['/login']);
        }
    }



    LoadData() {
        this._http.get(this.baseUrl + 'api/IssueHardware').subscribe(result => {
            debugger;
            this.IssueHardwareList = result.json() as IssueHardwareModal[];
        });
    }

    LoadHardwareTypes() {
        this._http.get(this.baseUrl + 'api/IssueHardware/GetAvailableHardwareTypes').subscribe(result => {
            this.hardwareTypeList = result.json() as hardwareTypeModal[];
        });
    }


    LoadAllUserName() {   
        this._http.get(this.baseUrl + 'api/Users/GetUsersName').subscribe(result => {
            this.userTypeList = result.json() as userTypeModal[];
        });
    }




    onSave() {
        if (this.checkValidation()) {  
            debugger;
            if (this.Modal.id == 0) {
                debugger;

                this._http.post(this.baseUrl + 'api/IssueHardware', this.Modal).subscribe((res) => {
                    this.LoadData();
                    this.onCancel();
                });
            }
            else {
                this._http.put(this.baseUrl + 'api/Hardwares', this.Modal).subscribe(result => {
                    this.LoadData();
                    this.onCancel();
                });
            }
        }
        else {
            this._appComp.popupHeader = "Error Message";
            this._appComp.popupBody = this.errorMessage;
            this._appComp.ShowPopup();
        }
    }



    hardwareChange(id: number) {       
        if (id != 0) {
            this.cpuParts = true;
        }
        else {
            this.cpuParts = false;
        }
    }

    
    userNameChange(id: number) {       
        if (id != 0) {
            this.cpuParts = true;
        }
        else {
            this.cpuParts = false;
        }
    }




    onCancel() {
        this.Modal.id = 0;
        this.Modal.userId = 0;
        this.Modal.hardwareTypeId = 0;
        //this.Modal.quantity = 0;             
        this.buttonName = "Save";
    }



    checkValidation(): boolean {     
        this.errorMessage = "";
        if (this.Modal.userId == 0) {
            this.errorMessage += " * Please enter alloceted User" + "<br />";
        }
        if (this.Modal.hardwareTypeId == 0) {
            this.errorMessage += " * Please enter Hardware Name" + "<br />";
        }

        //if (this.Modal.quantity == 0) {
        //    this.errorMessage += " * Please select vendor name" + "<br />";
        //}

        if (this.errorMessage == "") {
            return true;
        }
        else {
            return false;
        }
    }

    onDelete(id: number) {
        this._http.delete(this.baseUrl + 'api/IssueHardware/' + id).subscribe((res) => {
            this.LoadData();
        });
    }

}
class hardwareTypeModal {
    hardwareTypeId: number = 0;
    hardwareType: string = "";
}

class userTypeModal {
    userId: number = 0;
    name: string = "";
}


class IssueHardwareModal {
    id: number = 0;
    userId: number = 0;
    name: string = "";
    hardwareTypeId = 0;
    hardwareType: string = "";
    allocationDate: string = "";
}

class PostIssueHardwareModel {
    id: number = 0;
    userId: number = 0;
    hardwareTypeId = 0;
}

