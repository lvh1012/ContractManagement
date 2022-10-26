import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class InputSwitchControl extends BaseControl {
  override controlType = 'InputSwitch';

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
  }) {
    super(options);
  }
}
