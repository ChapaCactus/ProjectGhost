namespace Ghost
{
	public class PowerPotModel
	{
		public string ID { get; set; } = "";
		public float ChargeSpeed { get; set; } = 1.0f;

		public PowerPotModel(string id, float chargeSpeed)
		{
			ID = id;

			ChargeSpeed = chargeSpeed;
		}
	}
}