import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { getPositionsOf } from 'src/app/helpers/positionHelper';
import { Player } from 'src/app/models/Player';

@Component({
  selector: 'app-add-depth-modal',
  templateUrl: './add-depth-modal.component.html',
  styleUrls: ['./add-depth-modal.component.scss']
})
export class AddDepthModalComponent implements OnInit {
  positions: string[] = [];
  formFields: UntypedFormGroup = new UntypedFormGroup({});
  position = new UntypedFormControl('', Validators.required);
  depth = new UntypedFormControl(0, Validators.min(1));

  constructor(
    private formBuilder: UntypedFormBuilder,
    public dialogRef: MatDialogRef<AddDepthModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { player: Player}
  ) {}

  ngOnInit(): void {
    this.resetForm();
  }

  onYesClick(): void {
    if(this.isValid()) {
      this.dialogRef.close(this.formFields.value);
    }
  }

  clear(): void {
    this.resetForm();
  }

  isValid() : boolean {
    return this.formFields.valid;
  }

  private getPositions() {
    this.positions = getPositionsOf(this.data.player.team)
  }

  private resetForm() {
    this.formFields = this.formBuilder.group({
      position: this.position,
      depth: this.depth,
    });
    this.formFields.reset();
    this.getPositions();
  }
}
