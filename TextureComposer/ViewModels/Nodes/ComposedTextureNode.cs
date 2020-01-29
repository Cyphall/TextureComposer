﻿using System.Windows.Media;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace TextureComposer
{
	public class ComposedTextureNode : NodeViewModel
	{
		public ValueNodeInputViewModel<byte[,]> InR { get; } = new ValueNodeInputViewModel<byte[,]>();
		public ValueNodeInputViewModel<byte[,]> InG { get; } = new ValueNodeInputViewModel<byte[,]>();
		public ValueNodeInputViewModel<byte[,]> InB { get; } = new ValueNodeInputViewModel<byte[,]>();
		public ValueNodeInputViewModel<byte[,]> InA { get; } = new ValueNodeInputViewModel<byte[,]>();
		
		public ComposedTextureNode()
		{
			Name = "Composed Texture";
			
			InR.Name = "R";
			Inputs.Add(InR);
			
			InG.Name = "G";
			Inputs.Add(InG);
			
			InB.Name = "B";
			Inputs.Add(InB);
			
			InA.Name = "A";
			Inputs.Add(InA);
		}
		
		static ComposedTextureNode()
		{
			Splat.Locator.CurrentMutable.Register(() =>
			{
				NodeView view = new NodeView
				{
					Background = new SolidColorBrush(Color.FromRgb(0x50, 0x50, 0x50))
				};
				return view;
			}, typeof(IViewFor<ComposedTextureNode>));
		}
	}
}