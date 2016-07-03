public class Medicine_Reference{
	public Medicine_Reference(int amt, float breathAffect, ActionGeneric<int> handler){
		this.amt = amt;
		this.breathAffect = breathAffect;
		this.handler = handler;
	}

	 int _amt;
	public int amt{
		get{
			return _amt;
		}
		set{
			_amt = value;
			if(handler != null)
				handler(_amt);
		}
	}


	public float breathAffect;
	public ActionGeneric<int> handler;
}
