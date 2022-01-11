import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Company } from 'src/app/models/company.model';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-add-edit-company-modal',
  templateUrl: './add-edit-company-modal.component.html',
  styleUrls: ['./add-edit-company-modal.component.scss']
})
export class AddEditCompanyDialogComponent {

  companyId: number;
  companyForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(2)]),
    description: new FormControl('', [Validators.required, Validators.minLength(2)]),
    phone: new FormControl(''),
    webSite: new FormControl(''),
    logoUrl: new FormControl(),
    photoUrls: new FormControl()
  });
  get isEdit(): boolean {
    return this.companyId != null;
  }
  constructor(
    public dialogRef: MatDialogRef<AddEditCompanyDialogComponent>,
    private readonly companyService: CompanyService,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.companyId = data?.companyId;
    if (this.isEdit) {
        this.companyService.getCompanyById(this.companyId).subscribe(data => {
            this.companyForm.patchValue({
                companyId: data.id,
                name: data.name,
                description: data.description,
                phone: data.phone,
                webSite: data.webSite
            });
        })
    }
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.companyForm.invalid){
      return;
    }
    const company: Company = this.companyForm.value;
    if (this.isEdit) {
      this.companyService.updateCompany(this.companyId, company).subscribe(() => this.dialogRef.close(true), () => this.dialogRef.close(false));
    } else {
      this.companyService.addCompany(company).subscribe(() => this.dialogRef.close(true), () => this.dialogRef.close(false));;
    }
  }
}
