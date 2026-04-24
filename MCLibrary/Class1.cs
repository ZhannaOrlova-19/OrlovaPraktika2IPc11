using System;


namespace MyLibraryCalk
{
	public class CalcLibrary
	{
		public double Calculate(string vyrazhenie)
		{
			return ParseExpression(vyrazhenie.Replace(" ", ""));
		}
		private double ParseExpression(string vyrazhenie)
		{
			int urovenSkobok = 0;
			for (int i = 0; i < vyrazhenie.Length; i++)
			{
				char c = vyrazhenie[i];

				if (c == '(') urovenSkobok++;
				else if (c == ')') urovenSkobok--;

				if (urovenSkobok == 0 && (c == '+' || c == '-'))
				{
					string levayaChast = vyrazhenie.Substring(0, i);
					string pravayaChast = vyrazhenie.Substring(i + 1);

					double pervoeChislo = ParseExpression(levayaChast);
					double vtoroeChislo = ParseExpression(pravayaChast);

					switch (c)
					{
						case '+':
							return pervoeChislo + vtoroeChislo;
						case '-':
							return pervoeChislo - vtoroeChislo;
					}
				}
			}
			urovenSkobok = 0;
			for (int i = 0; i < vyrazhenie.Length; i++)
			{
				char c = vyrazhenie[i];

				if (c == '(') urovenSkobok++;
				else if (c == ')') urovenSkobok--;

				if (urovenSkobok == 0 && (c == '*' || c == '/' || c == '^'))
				{
					string levayaChast = vyrazhenie.Substring(0, i);
					string pravayaChast = vyrazhenie.Substring(i + 1);

					double first = ParseExpression(levayaChast);
					double second = ParseExpression(pravayaChast);

					switch (c)
					{
						case '*':
							return first * second;
						case '/':
							if (second == 0)
							{
								Console.WriteLine("Ошибка");
								return double.NaN;
							}
							return first / second;
						case '^':
							return Math.Pow(first, second);
					}
				}
			}
			if (vyrazhenie.StartsWith("(") && vyrazhenie.EndsWith(")"))
			{
				return ParseExpression(vyrazhenie.Substring(1, vyrazhenie.Length - 2));
			}

			return double.Parse(vyrazhenie, System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}
