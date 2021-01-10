import { Component, Inject, Input } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-image-dialog',
  templateUrl: './image-dialog.component.html',
  styleUrls: ['./image-dialog.component.scss']
})
export class ImageDialogComponent {

  @Input() imageUrls: string[];
  @Input() selectedImageUrl: string;

  constructor(
    public dialogRef: MatDialogRef<ImageDialogComponent>) { }

  closeDialog(): void {
    this.dialogRef.close();
  }

}
