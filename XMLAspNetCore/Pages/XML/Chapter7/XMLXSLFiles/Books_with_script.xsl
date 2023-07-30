<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schema-microsoft-com:xslt"
				xmlns:myDiscount="urn:myDiscount">
	<msxsl:script language="C#" implements-prefix="myDiscount">
		<![CDATA[
		public string ReturnDiscount(string price)
		{
		    decimal priceValue = Convert.ToDecimal(price);
			return (priceValue * 15/100).ToString();
		}
		]]>
	</msxsl:script>
	<xsl:output method="html" indent="yes" />
	<xsl:template match="/">
		<html>
			<title>XSL Transformation</title>
			<body style="background-color: lightblue;font-size: 24px">
				<h2>My Book Collection</h2>
				<table border="1">
					<tr bgcolor="#9acd32">
						<th align="left">Title</th>
						<th align="left">Price</th>
						<th align="left">Calculated Discount</th>
					</tr>
					<xsl:for-each select="bookstore/book">
						<tr>
							<td>
								<xsl:value-of select="title" />
							</td>
							<td>
								<xsl:value-of select="price" />
							</td>
							<td>
								<xsl:value-of select="myDiscount:ReturnDiscount(price)" />
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>