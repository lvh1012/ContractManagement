import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class InputTextareaControl extends BaseControl {
  override controlType = 'InputTextarea';
  rows?: number;
  cols?: number;
  autoResize?: boolean;

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
    rows?: number;
    cols?: number;
    autoResize?: boolean;
  }) {
    super(options);
    this.rows = options.rows || 3;
    this.cols = options.cols || 3;
    this.autoResize = !!options.autoResize || false
  }
}
