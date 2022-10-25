import { Validators } from '@angular/forms';

export class BaseControl {
  key: string;
  label: string;
  type?: string;
  value?: string | number | Date;
  required?: boolean;
  controlType?: string;
  width?: number;
  placeholder?: string;
  disabled?: boolean;
  readonly?: boolean;
  appendTo?: string;
  showClear?: boolean;
  validators?: Validators[];

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
    this.key = options.key;
    this.label = options.label;
    this.type = options.type;
    this.value = options.value;
    this.required = !!options.required || false;
    this.controlType = options.controlType;
    this.width = options.width || 12;
    this.validators = options.validators || [];
    this.placeholder = options.placeholder;
    this.disabled = !!options.disabled || false;
    this.readonly = !!options.readonly || false;
    this.appendTo = options.appendTo || 'body';
    this.showClear = !!options.showClear || false;
  }
}
