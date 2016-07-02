public delegate void MedicineHandler(Player player);

public class Medicine_Reference{
	public Medicine_Reference(int amt, MedicineHandler handler){
		this.amt = amt;
		this.handler = handler;
	}

	public int amt;
	public MedicineHandler handler;
}
