using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;


namespace CodeGen
{
	/// <summary>
	/// Example code builder using CodeDOM.
	/// </summary>
	public class CodedomCalculator 
	{
		
		public CodedomCalculator()
		{
			//
			// Required for Windows Form Designer support
			//
            //GetMathMemberNames();  // track all members of the math namespace

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		
		
		

        ICodeCompiler CreateCompiler()
        {
            //Create an instance of the C# compiler   
            CodeDomProvider codeProvider = null;
            codeProvider = new CSharpCodeProvider();
           ICodeCompiler compiler = codeProvider.CreateCompiler();
            return compiler;
        }

        /// <summary>
        /// Creawte parameters for compiling
        /// </summary>
        /// <returns></returns>
        CompilerParameters  CreateCompilerParameters()
        {
            //add compiler parameters and assembly references
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Numerics.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            //add any aditional references needed
//            foreach (string refAssembly in code.References)
  //              compilerParams.ReferencedAssemblies.Add(refAssembly);

            return compilerParams;
        }

        
        /// <summary>
        /// Compiles the code from the code string
        /// </summary>
        /// <param name="compiler"></param>
        /// <param name="parms"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private CompilerResults CompileCode(ICodeCompiler compiler, CompilerParameters parms, string source)
        {
                        //actually compile the code
            CompilerResults results = compiler.CompileAssemblyFromSource(
                                        parms, source); 

            //Do we have any compiler errors?
          if (results.Errors.Count > 0)
            {
                foreach (CompilerError error in results.Errors)
                {
                    MessageBox.Show ( error.ErrorText ,"Compile Error:" );
                }
                return null;
            }  

            return results;
        }

        /// <summary>
        /// Compiles the c# into an assembly if there are no syntax errors
        /// </summary>
        /// <returns></returns>
        private CompilerResults CompileAssembly()
        {
            // create a compiler
            ICodeCompiler compiler = CreateCompiler();
            // get all the compiler parameters
            CompilerParameters parms = CreateCompilerParameters();
            // compile the code into an assembly
            CompilerResults results = CompileCode(compiler, parms, _source.ToString());
            return results;

        }
        public static Object _classInstance;
        static MethodInfo m_info;
        static FieldInfo f_z_info;
        static FieldInfo f_c_info;

		public bool CreateInstanceReady(string userExpr)
		{
            _classInstance = null;
            // change evaluation string to pick up Math class members
            //string expression = RefineEvaluationString(txtCalculate.Text);
            info.lundin.math.ExpressionParser parser = new info.lundin.math.ExpressionParser();
            Hashtable ht = new Hashtable();
            ht.Add("z", "z");
            ht.Add("c", "c");
            ht.Add("i", "System.Numerics.Complex.ImaginaryOne");
            ht.Add("e", "System.Math.E");
            ht.Add("pi", "System.Math.PI");


            string expression = parser.Parse(userExpr, ht);

            // build the class using codedom
            BuildClass(expression);

            // compile the class into an in-memory assembly.
            // if it doesn't compile, show errors in the window
            CompilerResults results = CompileAssembly();

            //Console.WriteLine("...........................\r\n");
            //Console.WriteLine(_source.ToString());

            // if the code compiled okay,
            // run the code using the new assembly (which is inside the results)
            if (results != null && results.CompiledAssembly != null)
            {
                // run the evaluation function
                Assembly executingAssembly = results.CompiledAssembly;
                try
                {
                    //cant call the entry method if the assembly is null
                    if (executingAssembly != null)
                    {
                        _classInstance =  executingAssembly.CreateInstance("ExpressionEvaluator.Calculator");
                        f_z_info = _classInstance.GetType().GetField("z");
                        f_c_info = _classInstance.GetType().GetField("c");
                        m_info = _classInstance.GetType().GetMethod("Calculate");

                        return true;
                    }
                }
                catch (Exception)
                { }
            

                //RunCode(results);
            }
            return false;
        }

        public System.Numerics.Complex ExecuteExpressionValue(System.Numerics.Complex _z, System.Numerics.Complex _c)
        {
            try
            {
                f_z_info.SetValue(_classInstance, _z);
                f_c_info.SetValue(_classInstance, _c);
                Object res = m_info.Invoke(_classInstance, null);
                return (System.Numerics.Complex)res;
            }
            catch (Exception e)
            { 
            }
            return System.Numerics.Complex.Zero;
        }

        ArrayList _mathMembers = new ArrayList();
        Hashtable _mathMembersMap = new Hashtable();

        void GetMathMemberNames()
        {
            // get a reflected assembly of the System assembly
            Assembly systemAssembly = Assembly.GetAssembly(typeof(System.Math));
            try
            {
                //cant call the entry method if the assembly is null
                if (systemAssembly != null)
                {
                    //Use reflection to get a reference to the Math class

                    Module[] modules = systemAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the Math class
                    foreach (Type type in types)
                    {
                        if (type.Name == "Math")
                        {
                            // get all of the members of the math class and map them to the same member
                            // name in uppercase
                            MemberInfo[] mis = type.GetMembers();
                            foreach (MemberInfo mi in mis)
                            {
                                _mathMembers.Add(mi.Name);
                                _mathMembersMap[mi.Name.ToUpper()] = mi.Name;
                            }
                        }
                        //if the entry point method does return in Int32, then capture it and return it
                    }


                    //if it got here, then there was no entry point method defined.  Tell user about it
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:  An exception occurred while executing the script", ex);
            }
        }

        

		CodeMemberField FieldVariable(string fieldName, string typeName, MemberAttributes accessLevel)
		{
            CodeMemberField field = new CodeMemberField(typeName, fieldName);
            field.Attributes = accessLevel;
            return field;
		}
        CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel)
		{
            CodeMemberField field = new CodeMemberField(type, fieldName);
            field.Attributes = accessLevel;
            return field;
		}

		/// <summary>
		/// Very simplistic getter/setter properties
		/// </summary>
		/// <param name="propName"></param>
		/// <param name="internalName"></param>
		/// <param name="type"></param>
		/// <returns></returns>
        CodeMemberProperty MakeProperty(string propertyName, string internalName, Type type)
		{
            CodeMemberProperty myProperty = new CodeMemberProperty();
			myProperty.Name = propertyName;
            myProperty.Comments.Add(new CodeCommentStatement(String.Format("The {0} property is the returned result", propertyName)));
			myProperty.Attributes = MemberAttributes.Public;
			myProperty.Type = new CodeTypeReference(type);
			myProperty.HasGet = true;			
			myProperty.GetStatements.Add(
				new CodeMethodReturnStatement(
					new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName)));

			myProperty.HasSet = true;
			myProperty.SetStatements.Add(
				new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName), 
					new CodePropertySetValueReferenceExpression()));

			return myProperty;
		}


        StringBuilder _source = new StringBuilder();

		/// <summary>
		/// Main driving routine for building a class
		/// </summary>
		void BuildClass(string expression)
		{
            // need a string to put the code into
            _source = new StringBuilder();
            StringWriter sw = new StringWriter(_source);

			//Declare your provider and generator
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			ICodeGenerator generator = codeProvider.CreateGenerator(sw);			
			CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

			CodeNamespace myNamespace = new CodeNamespace("ExpressionEvaluator");
			myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));
            myNamespace.Imports.Add(new CodeNamespaceImport("System.Numerics"));

			//Build the class declaration and member variables			
			CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration();
			classDeclaration.IsClass = true;
			classDeclaration.Name = "Calculator";
			classDeclaration.Attributes = MemberAttributes.Public;
			classDeclaration.Members.Add(FieldVariable("answer", typeof(System.Numerics.Complex), MemberAttributes.Public));
            classDeclaration.Members.Add(FieldVariable("z", typeof(System.Numerics.Complex), MemberAttributes.Public));
            classDeclaration.Members.Add(FieldVariable("c", typeof(System.Numerics.Complex), MemberAttributes.Public));

			//default constructor
			CodeConstructor defaultConstructor = new CodeConstructor();
			defaultConstructor.Attributes = MemberAttributes.Public;
			defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
			defaultConstructor.Statements.Add(new CodeSnippetStatement("//TODO: implement default constructor"));
			classDeclaration.Members.Add(defaultConstructor);

			//property
            classDeclaration.Members.Add(this.MakeProperty("Answer", "answer", typeof(System.Numerics.Complex)));

			//Our Calculate Method
			CodeMemberMethod myMethod = new CodeMemberMethod();
			myMethod.Name = "Calculate";
            myMethod.ReturnType = new CodeTypeReference(typeof(System.Numerics.Complex));
			myMethod.Comments.Add(new CodeCommentStatement("Calculate an expression", true));
			myMethod.Attributes = MemberAttributes.Public;
            myMethod.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Answer"), new CodeSnippetExpression(expression)));
//            myMethod.Statements.Add(new CodeSnippetExpression("MessageBox.Show(String.Format(\"Answer = {0}\", Answer))"));
            myMethod.Statements.Add(
                new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Answer")));
			classDeclaration.Members.Add(myMethod);
			//write code
			myNamespace.Types.Add(classDeclaration);
			generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
			sw.Flush();
			sw.Close();
		}
	
	}
}

