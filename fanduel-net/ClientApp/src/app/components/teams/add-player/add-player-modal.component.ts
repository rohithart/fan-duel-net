import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Player } from 'src/app/models/Player';
import { Team } from 'src/app/models/Team';

@Component({
  selector: 'app-add-player-modal',
  templateUrl: './add-player-modal.component.html',
  styleUrls: ['./add-player-modal.component.scss']
})
export class AddPlayerModalComponent implements OnInit {

  formFields: UntypedFormGroup = new UntypedFormGroup({});
  name = new UntypedFormControl('', Validators.required);
  num = new UntypedFormControl(0, [Validators.required, Validators.min(1)]);

  constructor(
    private formBuilder: UntypedFormBuilder,
    public dialogRef: MatDialogRef<AddPlayerModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {team: Team}
  ) {}

  ngOnInit(): void {
    this.resetForm();
  }

  onYesClick(): void {
    if(this.isValid()) {
      const player = new Player('', parseInt(this.formFields.get('num')?.value), this.formFields.get('name')?.value, this.data.team)
      this.dialogRef.close(player);
    }
  }

  clear(): void {
    this.resetForm();
  }

  isValid() : boolean {
    return this.formFields.valid;
  }

  private resetForm() {
    this.formFields = this.formBuilder.group({
      name: this.name,
      num: this.num,
      team: this.data.team,
    });
    this.formFields.reset();
  }
}
