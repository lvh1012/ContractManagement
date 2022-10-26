import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class InputTextControl extends BaseControl {
  override controlType = 'InputText';
  style?: any;

  constructor(options: {
    key: string;
    label: string;
    type?: string;
    value?: string | number;
    required?: boolean;
    controlType?: string;
    width?: number;
    placeholder?: string;
    disabled?: boolean;
    readonly?: boolean;
    appendTo?: string;
    showClear?: boolean;
    validators?: Validators[];
    style?: any;
  }) {
    super(options);
    this.style = options.style;
  }
}
