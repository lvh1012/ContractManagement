export class BaseField {
  value: any;
  key: string;
  label: string;
  required: boolean;
  order: number;
  controlType: 'DatePicker' | 'Checkbox' | 'ColorPicker' | 'Dropdown' | 'Editor' | 'InputSwitch' | 'InputText' | 'InputTextArea' | 'InputNumber' | 'Radio' | 'Rating';
  type: string;
  options: { key: string, value: string }[];
  width: number;

  constructor(options: {
    value?: any;
    key?: string;
    label?: string;
    required?: boolean;
    order?: number;
    controlType?: 'DatePicker' | 'Checkbox' | 'ColorPicker' | 'Dropdown' | 'Editor' | 'InputSwitch' | 'InputText' | 'InputTextArea' | 'InputNumber' | 'Radio' | 'Rating';
    type?: string;
    options?: { key: string, value: string }[];
    width?: number
  } = {}) {
    this.value = options.value;
    this.key = options.key || '';
    this.label = options.label || '';
    this.required = !!options.required;
    this.order = options.order === undefined ? 1 : options.order;
    this.controlType = options.controlType || 'InputText';
    this.type = options.type || '';
    this.options = options.options || [];
    this.width = options.width || 12;
  }
}
