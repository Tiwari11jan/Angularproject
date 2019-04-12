import { Component, ViewChild, ElementRef, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AppComponent } from '../app/app.component';
import { Router } from '@angular/router';

@Component({
    selector: 'addhardwarelist-page',
    templateUrl: './addhardwarelist.component.html'
})
export class AddHardwareListComponent { 

    hardwareList: hardwareDetailsModal[] = [];

    hardwareTypeList: hardwareTypeModal[] = [];

    Modal = new hardwareDetailsModal();

    buttonName: string = "Save";
    public id: number = 0;
    errorMessage: string = "";
    cpuParts: boolean = false;

    constructor(private _http: Http, @Inject('BASE_URL') private baseUrl: string, private _appComp: AppComponent, private router: Router) {
        this.LoadHardwareTypes();
        this.LoadData();

    }

    ngOnInit() {
        if (sessionStorage.length == 0) {
            this.router.navigate(['/login']);
        }
    }

    

    LoadData() {
        this._http.get(this.baseUrl + 'api/Hardwares').subscribe(result => {
            this.hardwareList = result.json() as hardwareDetailsModal[];
        });
    }


    LoadHardwareTypes() {
        this._http.get(this.baseUrl + 'api/Hardwares/GetHardwareTypes').subscribe(result => {
            debugger;
            this.hardwareTypeList = result.json() as hardwareTypeModal[];
        });
    }

    onSave() {
        debugger;
        if (this.checkValidation()) {

            if (this.Modal.id == 0) {
                this._http.post(this.baseUrl + 'api/Hardwares', this.Modal).subscribe((res) => {
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

    onEdit(id: number) {
        this.buttonName = "Update";
        this._http.get(this.baseUrl + 'api/Hardwares/' + id).subscribe(result => {
            this.Modal = result.json() as hardwareDetailsModal;
            this.Modal.purchaseDate = this.Modal.purchaseDate.split('T')[0];
        });
    }

    hardwareChange(id: number) {
        if (id == 4) {
            this.cpuParts = true;
        }
        else {
            this.cpuParts = false;
        }
    }

    setDeleteId(id: number) {
        this.id = id;
    }

    onDelete() {
        debugger;
        this._http.delete(this.baseUrl + 'api/Hardwares/' + this.id).subscribe((res) => {
            this.LoadData();
        });
    }


    checkValidation(): boolean {
        debugger;
        this.errorMessage = "";
        if (this.Modal.make == "") {
            this.errorMessage = " * Please enter make" + "<br />";
        }

        if (this.Modal.modelNo == "") {
            this.errorMessage += " * Please enter model no" + "<br />";
        }
        if (this.Modal.serialNo == "") {
            this.errorMessage += " * Please enter serial no" + "<br />";
        }
        if (this.Modal.purchaseDate == "") {
            this.errorMessage += " * Please select purchase date" + "<br />";
        }

        if (this.Modal.quantity == 0) {
            this.errorMessage += " * Please select vendor name" + "<br />";
        }

        if (this.Modal.hardwareTypeId == 0) {
            this.errorMessage += " * Please select hardware type" + "<br />";
        }
        if (this.errorMessage == "") {
            return true;
        }
        else {
            return false;
        }
    }


    onCancel() {
        this.Modal.id = 0;
        this.Modal.make = "";
        this.Modal.modelNo = "";
        this.Modal.serialNo = "";
        this.Modal.purchaseDate = "";
        this.Modal.quantity = 0;
        this.Modal.vendorName = "";
        this.Modal.hardwareTypeId = 0;
        this.Modal.hardwareType = "";
        this.buttonName = "Save";
    }
}



class hardwareTypeModal {
    id: number = 0;
    hardwareType: string = "";
}

class hardwareDetailsModal {
    id: number = 0;
    make: string = "";
    modelNo: string = "";
    serialNo: string = "";
    purchaseDate: string = "";
    quantity: number = 0;
    vendorName: string = "";
    hardwareTypeId: number = 0;
    hardwareType: string = "";
}
