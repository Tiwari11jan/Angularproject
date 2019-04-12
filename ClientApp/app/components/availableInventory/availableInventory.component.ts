import { Component, ViewChild, ElementRef, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AppComponent } from '../app/app.component';
import { Router } from '@angular/router';

@Component({
    selector: 'availableInventory-page',
    templateUrl: './availableInventory.component.html'
})
export class AvailableInventoryListComponent {
    hardwareList: hardwareDetailsModal[] = [];

    constructor(private _http: Http, @Inject('BASE_URL') private baseUrl: string, private _appComp: AppComponent, private router: Router) {
        this.LoadData();
    }

    //ngOnInit() {
    //    if (sessionStorage.length == 0) {
    //        this.router.navigate(['/login']);
    //    }
    //}

    onSave() {
    //    this.Modal.vendorName = this.vendorName.nativeElement.value;
    //    if (this.Modal.vendorName == "") {
    //        this._appComp.popupHeader = "Information";
    //        this._appComp.popupBody = "Please Enter Vendor Name.";
    //        this._appComp.ShowPopup();
    //        return;
    //    }
    //    if (this.Modal.id == 0) {
    //        this._http.post(this.baseUrl + 'api/Vendors', this.Modal).subscribe((res) => {
    //            this.LoadData();
    //            this.onCancel();
    //        });
    //    }
    //    else {
    //        this._http.put(this.baseUrl + 'api/Vendors', this.Modal).subscribe(result => {
    //            this.LoadData();
    //            this.onCancel();
    //        })
    //    }
    }

    LoadData() {
        this._http.get(this.baseUrl + 'api/Hardwares').subscribe(result => {
            debugger;
            this.hardwareList = result.json() as hardwareDetailsModal[];
        });
    }

    onEdit(id: number) {
    //    this.buttonName = "Update";
    //    this._http.get(this.baseUrl + 'api/Vendors/' + id).subscribe(result => {
    //        this.Modal = result.json() as vendorModal;
    //        this.vendorName.nativeElement.value = this.Modal.vendorName;
    //    });
    }


    //setDeleteId(id: number) {
    //    this.id = id;
    //}

    onDelete() {
    //    this._http.delete(this.baseUrl + 'api/Vendors/' + this.id).subscribe((res) => {
    //        this.LoadData();
    //    });
    }


    //onCancel() {
    //    this.vendorName.nativeElement.value = "";
    //    this.Modal.id = 0;
    //    this.Modal.vendorName = "";
    //    this.buttonName = "Save";
    //}
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
