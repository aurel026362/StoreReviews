import { Component, Inject, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-add-edit-company-modal',
  templateUrl: './add-edit-company-modal.component.html',
  styleUrls: ['./add-edit-company-modal.component.scss']
})
export class AddEditCompanyDialogComponent {

  companyId: number;
  companyForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    phone: new FormControl(''),
    webSite: new FormControl('')
  });
  get isEdit(): boolean {
    return this.companyId != null;
  }
  constructor(
    public dialogRef: MatDialogRef<AddEditCompanyDialogComponent>,
    private readonly shopService: CompanyService,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.companyId = data?.shopId;
    // if (this.isEdit) {
    //     this.shopService.getStoreById(this.shopId).subscribe(data => {

    //         this.shopForm.patchValue({
    //             companyId: data.companyId,
    //             address: data.address,
    //             description: data.description,
    //             phone: data.phone
    //         });
    //     })
    // }
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    // const shop: Shop = this.shopForm.value;
    // if (this.isEdit) {
    //   this.shopService.updateShop(this.shopId, shop).subscribe(() => this.dialogRef.close(true), () => this.dialogRef.close(false));
    // } else {
    //   this.shopService.addShop(shop).subscribe(() => this.dialogRef.close(true), () => this.dialogRef.close(false));;
    // }
  }
}
