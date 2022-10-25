import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class InputMaskControl extends BaseControl {
  override controlType = 'InputMask';
  characterPattern?: string;
  mask?: string;
  slotChar?: string;

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
    characterPattern?: string;
    mask?: string;
    slotChar?: string;
  }) {
    super(options);
    this.characterPattern = options.characterPattern || '[A-Za-z]';
    this.mask = options.mask;
    this.slotChar = options.slotChar || '_';
  }
}
