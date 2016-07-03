public class Medicine_Reference{
	public Medicine_Reference(int amt, float breathAffect, Action handler){
		this.amt = amt;
		this.breathAffect = breathAffect;
		this.handler = handler;
	}

	public int amt;
	public float breathAffect;
	public Action handler;
}
