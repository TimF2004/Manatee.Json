﻿namespace Manatee.Json.Schema.Validators
{
	internal abstract class FormatSchemaPropertyValidatorBase<T> : IJsonSchemaPropertyValidator<T>
		where T : IJsonSchema
	{
		protected abstract StringFormat GetFormat(T schema);
		
		public bool Applies(T schema, JsonValue json)
		{
			return GetFormat(schema) != StringFormat.NotDefined && JsonSchemaOptions.ValidateFormat &&
			       json.Type == JsonValueType.String;
		}
		public SchemaValidationResults Validate(T schema, JsonValue json, JsonValue root)
		{
			var format = GetFormat(schema);
			if (!StringFormatValidator.Validate<T>(format, json.String))
				return new SchemaValidationResults(string.Empty, $"Value [{json.String}] is not in an acceptable {format} format.");
			return new SchemaValidationResults();
		}
	}
	
	internal class FormatSchema04PropertyValidator : FormatSchemaPropertyValidatorBase<JsonSchema04>
	{
		protected override StringFormat GetFormat(JsonSchema04 schema)
		{
			return schema.Format;
		}
	}
	
	internal class FormatSchema06PropertyValidator : FormatSchemaPropertyValidatorBase<JsonSchema06>
	{
		protected override StringFormat GetFormat(JsonSchema06 schema)
		{
			return schema.Format;
		}
	}
	
	internal class FormatSchema07PropertyValidator : FormatSchemaPropertyValidatorBase<JsonSchema07>
	{
		protected override StringFormat GetFormat(JsonSchema07 schema)
		{
			return schema.Format;
		}
	}
}
