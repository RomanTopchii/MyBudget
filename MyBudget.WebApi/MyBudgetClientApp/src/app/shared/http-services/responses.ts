import {Guid} from '../common/Guid';
import {Classification, KeeperGroup, KeeperType, TransactionItemType} from './requests';

//---------------------------------------------------------------
//Core
//---------------------------------------------------------------

export interface BaseEntityDto extends IdentifiableDto {
  active: boolean;
  createDate?: Date;
  createdBy?: string;
  modifyDate?: Date;
  modifiedBy?: string;
}

export interface DictionaryEntityDto extends BaseEntityDto {
  name: string;
}

export interface IdentifiableDto {
  id: Guid;
}

//---------------------------------------------------------------
//Custom
//---------------------------------------------------------------

export interface AccountSimpleDto extends DictionaryEntityDto {
}

export interface AccountTypeNamedDto extends DictionaryEntityDto {
}


export interface AccountTypeRichDto extends DictionaryEntityDto {
  classification?: Classification;
  hasCurrency: boolean;
  hasHolder: boolean;
  hasKeeper: boolean;
  linkedAccountType?: AccountTypeNamedDto;
  hasInitialBalance: boolean;
  calcFullTimeBalance: boolean;
  canBeDeleted: boolean;
  canChangeActiveStatus: boolean;
  canBeRenamed: boolean;
  canBeCreatedByUser: boolean;
  checkAmountBeforeDeactivate: boolean;
  allowsTransactions: boolean;
  keeperGroup: KeeperGroup;
  priority: number;
  children: AccountTypeNamedDto[];
  ancestors: AccountTypeNamedDto[];
}

export interface CurrencySimpleDto extends BaseEntityDto {
  code: string;
  iso4217: number;
  isAccounting: boolean;
}

export interface HolderSimpleDto extends DictionaryEntityDto {
}

export interface KeeperSimpleDto extends DictionaryEntityDto {
  type: KeeperType;
}

export interface TransactionDto extends IdentifiableDto {
  date: Date;
  comment: string;
  items: TransactionItemDto[];
}

export interface TransactionItemDto extends IdentifiableDto {
  account: AccountSimpleDto;
  amount: number;
  type: TransactionItemType;
}

export interface TransactionItemSimpleDto {
  id: Guid;
  accountId: Guid;
  amount: number;
  type: TransactionItemType;
}
