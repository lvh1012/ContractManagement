import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseField } from './models/base-field';

@Component({
  selector: 'app-form-base',
  templateUrl: './form-base.component.html',
  styleUrls: ['./form-base.component.scss']
})
export class FormBaseComponent implements OnInit {

  fields: BaseField[] = [
    new BaseField({
      key: 'firstName',
      label: 'First name',
      value: 'Bombasto',
      controlType: 'InputText',
      required: true,
      order: 1
    })
  ];
  form!: FormGroup;
  payLoad = '';

  constructor() { }

  ngOnInit() {
    this.form = this.toFormGroup(this.fields as BaseField[]);
  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
  }



  toFormGroup(fields: BaseField[]) {
    const group: any = {};

    fields.forEach(field => {
      group[field.key] = field.required ? new FormControl(field.value || '', Validators.required)
        : new FormControl(field.value || '');
    });
    return new FormGroup(group);
  }

  update() {
    this.form.patchValue({
      firstName: 'Nancy'
    });
  }
}
