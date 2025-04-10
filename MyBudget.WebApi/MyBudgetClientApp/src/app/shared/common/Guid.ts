export type TypeOrUndefined<T> = T | undefined;

export class Guid {
  public static empty = new Guid('00000000-0000-0000-0000-000000000000');

  private id! : string;

  constructor(value: TypeOrUndefined<Guid | string>) {
    if (!value) {
      return Guid.empty;
    }

    if(value instanceof Guid) {
      return new Guid(value.toString());
    }

    this.checkFormat(value);
    this.id = value.toLowerCase();
  }

  public static new(): Guid {
    function gen(): string{
      return Math.floor((1+Math.random()) * 0x10000)
        .toString(16)
        .substring(1);
    }

    return new Guid(`${gen()}${gen()}-${gen()}-${gen()}-${gen()}-${gen()}${gen()}${gen()}`)
  }

  public toString(): string {
    return this.id;
  }


  private checkFormat(value: string): void {
    const format=new RegExp('^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$', 'i');

    if(!format.test(value)) {
      throw new Error(`Incorrect guid format. Raw value '${value}'`);
    }
  }

}
