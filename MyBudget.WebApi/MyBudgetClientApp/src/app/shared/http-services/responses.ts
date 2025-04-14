import {Guid} from '../common/Guid';
import {KeeperType, TransactionItemType} from './requests';

//---------------------------------------------------------------
//Core
//---------------------------------------------------------------

export interface BaseEntityDto extends IdentifiableDto {
  active: boolean;
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

export interface AccountSimpleDto extends DictionaryEntityDto {}

export interface CurrencySimpleDto extends BaseEntityDto {
  code: string;
  iso4217: number;
  isAccounting: boolean;
}

export interface HolderSimpleDto extends DictionaryEntityDto {}

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
