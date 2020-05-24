using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BulletComposite : Bullet
{
	public BulletComposite() { }

	// Composite pattern implementation
	public List<Bullet> Childs { get; set; }
	public void Add(Bullet bulletComponent)
	{
		Childs.Add(bulletComponent);
	}
	public void Remove(Bullet bulletComponent)
	{
		Childs.Remove(bulletComponent);
	}
}
