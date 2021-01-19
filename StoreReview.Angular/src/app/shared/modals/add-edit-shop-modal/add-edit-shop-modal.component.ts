import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Shop } from 'src/app/models/shop.model';
import { StoreService } from 'src/app/services/store.service';

@Component({
    selector: 'app-add-edit-shop-modal',
    templateUrl: './add-edit-shop-modal.component.html',
    styleUrls: ['./add-edit-shop-modal.component.scss']
})
export class AddEditShopDialogComponent {
    
    shopId: number;
    shopForm = new FormGroup({
        address: new FormControl('', [Validators.required]),
        description: new FormControl('', [Validators.required]),
        phone: new FormControl(''),
        companyId: new FormControl('', [Validators.required]),
    });
    get isEdit(): boolean {
        return this.shopId != null;
    }
    constructor(
        public dialogRef: MatDialogRef<AddEditShopDialogComponent>,
        private readonly shopService: StoreService,
        @Inject(MAT_DIALOG_DATA) public data: any) {
        this.shopId = data?.shopId;
        this.shopForm.patchValue({
            companyId: data.companyId
        });
        if (this.isEdit) {
            this.shopService.getStoreById(this.shopId).subscribe(data => {

                this.shopForm.patchValue({
                    companyId: data.companyId,
                    address: data.address,
                    description: data.description,
                    phone: data.phone
                });
            })
        }
    }

    closeDialog(): void {
        this.dialogRef.close();
    }

    onSubmit(): void {
        const shop: Shop = this.shopForm.value;
        if (this.isEdit) {
            this.shopService.updateShop(this.shopId, shop).subscribe(()=>this.dialogRef.close(true), ()=> this.dialogRef.close(false));
        } else {
            this.shopService.addShop(shop).subscribe(()=>this.dialogRef.close(true), ()=> this.dialogRef.close(false));;
        }
    }

}
