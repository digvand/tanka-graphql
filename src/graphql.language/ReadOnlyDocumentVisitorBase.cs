﻿using System;
using Tanka.GraphQL.Language.Nodes;
using Tanka.GraphQL.Language.Nodes.TypeSystem;

namespace Tanka.GraphQL.Language
{
    public abstract class ReadOnlyDocumentVisitorBase<TContext> : IReadOnlyDocumentVisitor<TContext>
    {
        public virtual void EnterNode(TContext context, INode node)
        {
            switch (node)
            {
                case null:
                    break;
                case Argument argument:
                    EnterArgument(context, argument);
                    break;
                case BooleanValue booleanValue:
                    EnterBooleanValue(context, booleanValue);
                    break;
                case DefaultValue defaultValue:
                    EnterDefaultValue(context, defaultValue);
                    break;
                case Directive directive:
                    EnterDirective(context, directive);
                    break;
                case EnumValue enumValue:
                    EnterEnumValue(context, enumValue);
                    break;
                case ExecutableDocument executableDocument:
                    EnterExecutableDocument(context, executableDocument);
                    break;
                case FieldSelection fieldSelection:
                    EnterFieldSelection(context, fieldSelection);
                    break;
                case FloatValue floatValue:
                    EnterFloatValue(context, floatValue);
                    break;
                case FragmentDefinition fragmentDefinition:
                    EnterFragmentDefinition(context, fragmentDefinition);
                    break;
                case FragmentSpread fragmentSpread:
                    EnterFragmentSpread(context, fragmentSpread);
                    break;
                case InlineFragment inlineFragment:
                    EnterInlineFragment(context, inlineFragment);
                    break;
                case IntValue intValue:
                    EnterIntValue(context, intValue);
                    break;
                case ListType listType:
                    EnterListType(context, listType);
                    break;
                case ListValue listValue:
                    EnterListValue(context, listValue);
                    break;
                case NamedType namedType:
                    EnterNamedType(context, namedType);
                    break;
                case NonNullType nonNullType:
                    EnterNonNullType(context, nonNullType);
                    break;
                case NullValue nullValue:
                    EnterNullValue(context, nullValue);
                    break;
                case ObjectField objectField:
                    EnterObjectField(context, objectField);
                    break;
                case ObjectValue objectValue:
                    EnterObjectValue(context, objectValue);
                    break;
                case OperationDefinition operationDefinition:
                    EnterOperationDefinition(context, operationDefinition);
                    break;
                case SelectionSet selectionSet:
                    EnterSelectionSet(context, selectionSet);
                    break;
                case StringValue stringValue:
                    EnterStringValue(context, stringValue);
                    break;
                case DirectiveDefinition directiveDefinition:
                    EnterDirectiveDefinition(context, directiveDefinition);
                    break;
                case EnumDefinition enumDefinition:
                    EnterEnumDefinition(context, enumDefinition);
                    break;
                case EnumValueDefinition enumValueDefinition:
                    EnterEnumValueDefinition(context, enumValueDefinition);
                    break;
                case FieldDefinition fieldDefinition:
                    EnterFieldDefinition(context, fieldDefinition);
                    break;
                case Import import:
                    EnterImport(context, import);
                    break;
                case InputObjectDefinition inputObjectDefinition:
                    EnterInputObjectDefinition(context, inputObjectDefinition);
                    break;
                case InputValueDefinition inputValueDefinition:
                    EnterInputValueDefinition(context, inputValueDefinition);
                    break;
                case InterfaceDefinition interfaceDefinition:
                    EnterInterfaceDefinition(context, interfaceDefinition);
                    break;
                case ObjectDefinition objectDefinition:
                    EnterObjectDefinition(context, objectDefinition);
                    break;
                case ScalarDefinition scalarDefinition:
                    EnterScalarDefinition(context, scalarDefinition);
                    break;
                case SchemaDefinition schemaDefinition:
                    EnterSchemaDefinition(context, schemaDefinition);
                    break;
                case SchemaExtension schemaExtension:
                    EnterSchemaExtension(context, schemaExtension);
                    break;
                case UnionDefinition unionDefinition:
                    EnterUnionDefinition(context, unionDefinition);
                    break;
                case TypeExtension typeExtension:
                    EnterTypeExtension(context, typeExtension);
                    break;
                case TypeSystemDocument typeSystemDocument:
                    EnterTypeSystemDocument(context, typeSystemDocument);
                    break;
                case Variable variable:
                    EnterVariable(context, variable);
                    break;
                case VariableDefinition variableDefinition:
                    EnterVariableDefinition(context, variableDefinition);
                    break;
                case IReadOnlyCollectionNode<Argument> arguments:
                    EnterArguments(context, arguments);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(node));
            }
        }

        protected virtual void EnterArguments(TContext context, IReadOnlyCollectionNode<Argument> arguments)
        {
        }

        protected virtual void EnterImport(TContext context, Import import)
        {
        }

        protected virtual void EnterArgument(TContext context, Argument argument)
        {
        }

        protected virtual void EnterBooleanValue(TContext context, BooleanValue booleanValue)
        {
        }

        protected virtual void EnterDefaultValue(TContext context, DefaultValue defaultValue)
        {
        }

        protected virtual void EnterDirective(TContext context, Directive directive)
        {
        }

        protected virtual void EnterEnumValue(TContext context, EnumValue enumValue)
        {
        }

        protected virtual void EnterExecutableDocument(TContext context, ExecutableDocument executableDocument)
        {
        }

        protected virtual void EnterFieldSelection(TContext context, FieldSelection fieldSelection)
        {
        }

        protected virtual void EnterFloatValue(TContext context, FloatValue floatValue)
        {
        }

        protected virtual void EnterFragmentDefinition(TContext context, FragmentDefinition fragmentDefinition)
        {
        }

        protected virtual void EnterFragmentSpread(TContext context, FragmentSpread fragmentSpread)
        {
        }

        protected virtual void EnterInlineFragment(TContext context, InlineFragment inlineFragment)
        {
        }

        protected virtual void EnterIntValue(TContext context, IntValue intValue)
        {
        }

        protected virtual void EnterListType(TContext context, ListType listType)
        {
        }

        protected virtual void EnterListValue(TContext context, ListValue listValue)
        {
        }

        protected virtual void EnterNamedType(TContext context, NamedType namedType)
        {
        }

        protected virtual void EnterNonNullType(TContext context, NonNullType nonNullType)
        {
        }

        protected virtual void EnterNullValue(TContext context, NullValue nullValue)
        {
        }

        protected virtual void EnterObjectValue(TContext context, ObjectValue objectValue)
        {
        }

        protected virtual void EnterObjectField(TContext context, ObjectField objectField)
        {
        }

        protected virtual void EnterOperationDefinition(TContext context, OperationDefinition operationDefinition)
        {
        }

        protected virtual void EnterSelectionSet(TContext context, SelectionSet selectionSet)
        {
        }

        protected virtual void EnterStringValue(TContext context, StringValue stringValue)
        {
        }

        protected virtual void EnterDirectiveDefinition(TContext context, DirectiveDefinition directiveDefinition)
        {
        }

        protected virtual void EnterEnumDefinition(TContext context, EnumDefinition enumDefinition)
        {
        }

        protected virtual void EnterEnumValueDefinition(TContext context, EnumValueDefinition enumValueDefinition)
        {
        }

        protected virtual void EnterFieldDefinition(TContext context, FieldDefinition fieldDefinition)
        {
        }

        protected virtual void EnterInputObjectDefinition(TContext context, InputObjectDefinition inputObjectDefinition)
        {
        }

        protected virtual void EnterInputValueDefinition(TContext context, InputValueDefinition inputValueDefinition)
        {
        }

        protected virtual void EnterInterfaceDefinition(TContext context, InterfaceDefinition interfaceDefinition)
        {
        }

        protected virtual void EnterObjectDefinition(TContext context, ObjectDefinition objectDefinition)
        {
        }

        protected virtual void EnterScalarDefinition(TContext context, ScalarDefinition scalarDefinition)
        {
        }

        protected virtual void EnterSchemaDefinition(TContext context, SchemaDefinition schemaDefinition)
        {
        }

        protected virtual void EnterSchemaExtension(TContext context, SchemaExtension schemaExtension)
        {
        }

        protected virtual void EnterUnionDefinition(TContext context, UnionDefinition unionDefinition)
        {
        }

        protected virtual void EnterTypeExtension(TContext context, TypeExtension typeExtension)
        {
        }

        protected virtual void EnterTypeSystemDocument(TContext context, TypeSystemDocument typeSystemDocument)
        {
        }

        protected virtual void EnterVariable(TContext context, Variable variable)
        {
        }

        protected virtual void EnterVariableDefinition(TContext context, VariableDefinition variableDefinition)

        {
        }

        public virtual void ExitNode(TContext context, INode node)
        {
            switch (node)
            {
                case null:
                    break;
                case Argument argument:
                    ExitArgument(context, argument);
                    break;
                case BooleanValue booleanValue:
                    ExitBooleanValue(context, booleanValue);
                    break;
                case DefaultValue defaultValue:
                    ExitDefaultValue(context, defaultValue);
                    break;
                case Directive directive:
                    ExitDirective(context, directive);
                    break;
                case EnumValue enumValue:
                    ExitEnumValue(context, enumValue);
                    break;
                case ExecutableDocument executableDocument:
                    ExitExecutableDocument(context, executableDocument);
                    break;
                case FieldSelection fieldSelection:
                    ExitFieldSelection(context, fieldSelection);
                    break;
                case FloatValue floatValue:
                    ExitFloatValue(context, floatValue);
                    break;
                case FragmentDefinition fragmentDefinition:
                    ExitFragmentDefinition(context, fragmentDefinition);
                    break;
                case FragmentSpread fragmentSpread:
                    ExitFragmentSpread(context, fragmentSpread);
                    break;
                case InlineFragment inlineFragment:
                    ExitInlineFragment(context, inlineFragment);
                    break;
                case IntValue intValue:
                    ExitIntValue(context, intValue);
                    break;
                case ListType listType:
                    ExitListType(context, listType);
                    break;
                case ListValue listValue:
                    ExitListValue(context, listValue);
                    break;
                case NamedType namedType:
                    ExitNamedType(context, namedType);
                    break;
                case NonNullType nonNullType:
                    ExitNonNullType(context, nonNullType);
                    break;
                case NullValue nullValue:
                    ExitNullValue(context, nullValue);
                    break;
                case ObjectField objectField:
                    ExitObjectField(context, objectField);
                    break;
                case ObjectValue objectValue:
                    ExitObjectValue(context, objectValue);
                    break;
                case OperationDefinition operationDefinition:
                    ExitOperationDefinition(context, operationDefinition);
                    break;
                case SelectionSet selectionSet:
                    ExitSelectionSet(context, selectionSet);
                    break;
                case StringValue stringValue:
                    ExitStringValue(context, stringValue);
                    break;
                case DirectiveDefinition directiveDefinition:
                    ExitDirectiveDefinition(context, directiveDefinition);
                    break;
                case EnumDefinition enumDefinition:
                    ExitEnumDefinition(context, enumDefinition);
                    break;
                case EnumValueDefinition enumValueDefinition:
                    ExitEnumValueDefinition(context, enumValueDefinition);
                    break;
                case FieldDefinition fieldDefinition:
                    ExitFieldDefinition(context, fieldDefinition);
                    break;
                case Import import:
                    ExitImport(context, import);
                    break;
                case InputObjectDefinition inputObjectDefinition:
                    ExitInputObjectDefinition(context, inputObjectDefinition);
                    break;
                case InputValueDefinition inputValueDefinition:
                    ExitInputValueDefinition(context, inputValueDefinition);
                    break;
                case InterfaceDefinition interfaceDefinition:
                    ExitInterfaceDefinition(context, interfaceDefinition);
                    break;
                case ObjectDefinition objectDefinition:
                    ExitObjectDefinition(context, objectDefinition);
                    break;
                case ScalarDefinition scalarDefinition:
                    ExitScalarDefinition(context, scalarDefinition);
                    break;
                case SchemaDefinition schemaDefinition:
                    ExitSchemaDefinition(context, schemaDefinition);
                    break;
                case SchemaExtension schemaExtension:
                    ExitSchemaExtension(context, schemaExtension);
                    break;
                case UnionDefinition unionDefinition:
                    ExitUnionDefinition(context, unionDefinition);
                    break;
                case TypeExtension typeExtension:
                    ExitTypeExtension(context, typeExtension);
                    break;
                case TypeSystemDocument typeSystemDocument:
                    ExitTypeSystemDocument(context, typeSystemDocument);
                    break;
                case Variable variable:
                    ExitVariable(context, variable);
                    break;
                case VariableDefinition variableDefinition:
                    ExitVariableDefinition(context, variableDefinition);
                    break;
                case ReadOnlyCollectionNode<Argument> arguments:
                    ExitArguments(context, arguments);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(node));
            }
        }

        protected virtual void ExitArguments(TContext context, ReadOnlyCollectionNode<Argument> arguments)
        {
        }

        protected virtual void ExitImport(TContext context, Import import)
        {
        }

        protected virtual void ExitArgument(TContext context, Argument argument)
        {
        }

        protected virtual void ExitBooleanValue(TContext context, BooleanValue booleanValue)
        {
        }

        protected virtual void ExitDefaultValue(TContext context, DefaultValue defaultValue)
        {
        }

        protected virtual void ExitDirective(TContext context, Directive directive)
        {
        }

        protected virtual void ExitEnumValue(TContext context, EnumValue enumValue)
        {
        }

        protected virtual void ExitExecutableDocument(TContext context, ExecutableDocument executableDocument)
        {
        }

        protected virtual void ExitFieldSelection(TContext context, FieldSelection fieldSelection)
        {
        }

        protected virtual void ExitFloatValue(TContext context, FloatValue floatValue)
        {
        }

        protected virtual void ExitFragmentDefinition(TContext context, FragmentDefinition fragmentDefinition)
        {
        }

        protected virtual void ExitFragmentSpread(TContext context, FragmentSpread fragmentSpread)
        {
        }

        protected virtual void ExitInlineFragment(TContext context, InlineFragment inlineFragment)
        {
        }

        protected virtual void ExitIntValue(TContext context, IntValue intValue)
        {
        }

        protected virtual void ExitListType(TContext context, ListType listType)
        {
        }

        protected virtual void ExitListValue(TContext context, ListValue listValue)
        {
        }

        protected virtual void ExitNamedType(TContext context, NamedType namedType)
        {
        }

        protected virtual void ExitNonNullType(TContext context, NonNullType nonNullType)
        {
        }

        protected virtual void ExitNullValue(TContext context, NullValue nullValue)
        {
        }

        protected virtual void ExitObjectValue(TContext context, ObjectValue objectValue)
        {
        }

        protected virtual void ExitObjectField(TContext context, ObjectField objectField)
        {
        }

        protected virtual void ExitOperationDefinition(TContext context, OperationDefinition operationDefinition)
        {
        }

        protected virtual void ExitSelectionSet(TContext context, SelectionSet selectionSet)
        {
        }

        protected virtual void ExitStringValue(TContext context, StringValue stringValue)
        {
        }

        protected virtual void ExitDirectiveDefinition(TContext context, DirectiveDefinition directiveDefinition)
        {
        }

        protected virtual void ExitEnumDefinition(TContext context, EnumDefinition enumDefinition)
        {
        }

        protected virtual void ExitEnumValueDefinition(TContext context, EnumValueDefinition enumValueDefinition)
        {
        }

        protected virtual void ExitFieldDefinition(TContext context, FieldDefinition fieldDefinition)
        {
        }

        protected virtual void ExitInputObjectDefinition(TContext context, InputObjectDefinition inputObjectDefinition)
        {
        }

        protected virtual void ExitInputValueDefinition(TContext context, InputValueDefinition inputValueDefinition)
        {
        }

        protected virtual void ExitInterfaceDefinition(TContext context, InterfaceDefinition interfaceDefinition)
        {
        }

        protected virtual void ExitObjectDefinition(TContext context, ObjectDefinition objectDefinition)
        {
        }

        protected virtual void ExitScalarDefinition(TContext context, ScalarDefinition scalarDefinition)
        {
        }

        protected virtual void ExitSchemaDefinition(TContext context, SchemaDefinition schemaDefinition)
        {
        }

        protected virtual void ExitSchemaExtension(TContext context, SchemaExtension schemaExtension)
        {
        }

        protected virtual void ExitUnionDefinition(TContext context, UnionDefinition unionDefinition)
        {
        }

        protected virtual void ExitTypeExtension(TContext context, TypeExtension typeExtension)
        {
        }

        protected virtual void ExitTypeSystemDocument(TContext context, TypeSystemDocument typeSystemDocument)
        {
        }

        protected virtual void ExitVariable(TContext context, Variable variable)
        {
        }

        protected virtual void ExitVariableDefinition(TContext context, VariableDefinition variableDefinition)
        {
        }
    }
}