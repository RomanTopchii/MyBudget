import {Guid} from '../common/Guid';

//---------------------------------------------------------------
//ENUMS
//---------------------------------------------------------------

export enum Classification
{
  Assets = 0,
  Liabilities = 1
}

export enum KeeperGroup
{
  None = 0,
  Cash = 1,
  Bank = 2,
  NonCash = 3,
  Any = 4
}

export enum KeeperType
{
  Cash = 0,
  Bank = 1,
  Person = 2
}

export enum TransactionItemType
{
  Debit = 0,
  Credit = 1
}

//---------------------------------------------------------------
//COMMANDS
//---------------------------------------------------------------

export interface SaveAccountCommand {
  id: Guid | null;
  active: boolean;
  name: string;
  parentId: Guid | null;
  typeId: Guid;
  currencyId: Guid | null;
  holderId: Guid | null;
  keeperId: Guid | null;
  linkedAccountId: Guid | null;
}

export interface SaveAccountTypeCommand {
  id: Guid | null;
  active: boolean;
  name: string;
  classification: Classification | null;
  hasCurrency: boolean;
  hasHolder: boolean;
  hasKeeper: boolean;
  hasInitialBalance: boolean;
  calculateFullTimeBalance: boolean;
  canBeDeleted: boolean;
  canChangeActiveStatus: boolean;
  canBeRenamed: boolean;
  canBeCreatedByUser: boolean;
  checkAmountBeforeDeactivate: boolean;
  allowsTransactions: boolean;
  keeperGroup: KeeperGroup;
  priority: number;
  parentTypes: Guid[];
}

export interface SaveCurrencyCommand {
  id: Guid | null;
  active: boolean;
  code: string;
  iso4217: number;
}

export interface SetAccountingCurrencyCommand {
  newAccountingCurrencyId: Guid;
}

export interface SaveHolderCommand {
  id: Guid | null;
  active: boolean;
  name: string;
}

export interface SaveKeeperCommand {
  id: Guid | null;
  active: boolean;
  name: string;
  type: KeeperType;
}

//---------------------------------------------------------------
//QUERIES
//---------------------------------------------------------------
