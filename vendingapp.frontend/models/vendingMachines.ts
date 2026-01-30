import type {User} from '../models/user';

export interface VendingMachine {
  id: string;
  serialNumber: string;
  inventoryNumber: string;
  location: string;
  model: string;
  modelType: string;
  totalIncome: number;
  company: string;
  manufacterDate: Date;
  installDate: Date;
  lastMaintainceDate: Date;
  maintainceMonthInterval: number;
  resourceHours: number;
  nextMainainceDate: Date;
  serviceTime: number;
  status: string;
  country: string;
  inventoryDate: Date;
  maintainerId: string;
  maintainer?: User;
}
