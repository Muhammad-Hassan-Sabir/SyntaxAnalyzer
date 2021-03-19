using System.Collections.Generic;

namespace SyntaxAnalyzer
{
    class SyntaxChecking
    {

        static int index = 0;

        List<string[]> ts = new List<string[]>();


        public string SyntexAnalyzer(List<string[]> tokens)
        {

            this.ts = tokens;

            if (START_ST())
            {
                if (ts[index][0] == "$")
                {

                    return "No Syntax Error";
                }
                else
                {
                    return "Syntax Error at" + ts[index][2];
                }

            }




            return "Syntax Error";



        }






        bool START_ST()
        {
            if (ts[index][0] == "ACC_MOD")
            {


                index++;
                if (ts[index][0] == "class")
                {
                    index++;
                    if (ts[index][0] == "ID")
                    {

                        index++;
                        if (ts[index][0] == "{")
                        {

                           


                            index++;

                            if(BODY1())
                            {


                                if (ts[index][0] == "void")
                                {

                                    index++;

                                    if (ts[index][0] == "Main")
                                    {

                                        index++;

                                        if (ts[index][0] == "(")
                                        {

                                            index++;
                                            if (ts[index][0] == ")")
                                            {

                                                index++;

                                                if (ts[index][0] == "{")
                                                {

                                                    index++;

                                                    if (BODY())
                                                    {
                                                        if (ts[index][0] == "}")
                                                        {

                                                            index++;

                                                            if (BODY1())
                                                            {
                                                                if (ts[index][0] == "}")
                                                                {

                                                                    index++;

                                                                    return true;

                                                                }

                                                            }


                                                        }

                                                    }

                                                }
                                            }

                                        }
                                    }
                                }


                            }

                            
                        }


                    }
                }






            }



            return false;
        }

        //FIRST(<OE>)=FIRST(<AE>)={INT_CONST ,STRING_CONST , CHAR_C0NST , FLOAT_CONST ,BOOLEAN_CONST, ( , ! , INC_DEC , ID}

        bool OE()
        {

            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
            {
                
                if (AE())
                {

                    if (OE_())
                    {

                        return true;
                    }

                }


            }
            return false;
        }


        bool OE_()
        {
            if (ts[index][0] == "||")
            {
                index++;
                if (AE())
                {
                    if (OE_())
                    {
                        return true;
                    }
                }

            }
            else //FOLLOW(<OE'>)=FOLLOW(<OE>)= { ;  ,  )  ,  ]   ,  DT ,     ,}
            {
                if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == ",")
                {
                    return true;
                }

            }

            return false;

        }


        //FIRST(<AE>)=FIRST(<RE>)={INT_CONST ,STRING_CONST , CHAR_C0NST , FLOAT_CONST ,BOOLEAN_CONST, ( , ! , INC_DEC , ID}

        bool AE()
        {

            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
            {
                if (RE())
                {
                    if (AE_())
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        bool AE_()
        {
            if (ts[index][0] == "&&")
            {
                index++;
                if (AE())
                {
                    if (OE_())
                    {
                        return true;
                    }
                }

            }
            else //FOLLOW(<AE'>)=FOLLOW(<OE>)= { ;  ,  )  ,  ]   ,  DT ,   ||,  ,}
            {
                if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == "," || ts[index][0] == "||")
                {
                    return true;
                }

            }
            return false;
        }

        bool RE()
        {

            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
            {
               

                if (E())
                {


                    if (RE_())
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        bool RE_()
        {
            if (ts[index][0] == "ROP")
            {
                index++;
                if (E())
                {
                    if (RE_())
                    {
                        return true;
                    }
                }

            }
            else //  { &&  , ||  ,  ;  ,  )  ,  ]   ,  DT ,     ,}
            {
                if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == "," || ts[index][0] == "||" || ts[index][0] == "&&")
                {
                    return true;
                }

            }
            return false;

        }


        bool E()
        {

            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
            {
                if (T())
                {


                    if (E_())
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        bool E_()
        {
            if (ts[index][0] == "PM")
            {
                index++;

                if (T())
                {

                    if (E_())
                    {
                        return true;
                    }
                }

            }
            else //  { ROP , &&  , ||  ,  ;  ,  )  ,  ]   ,  DT ,     ,}
            {
                if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == "," || ts[index][0] == "||" || ts[index][0] == "&&" || ts[index][0] == "ROP")
                {
                    return true;
                }

            }
            return false;

        }


        bool T()
        {


            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
            {

                if (F())
                {


                    if (T_())
                    {

                        return true;
                    }

                }

            }
            return false;
        }

        bool T_()
        {
            if (ts[index][0] == "MDM")
            {
                index++;
                if (F())
                {
                    if (T_())
                    {
                        return true;
                    }
                }

            }
            else //  { PM , ROP , &&  , ||  ,  ;  ,  )  ,  ]   ,  DT ,     ,}
            {
                if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == "," || ts[index][0] == "||" || ts[index][0] == "&&" || ts[index][0] == "ROP" || ts[index][0] == "PM")
                {

                    return true;
                }

            }
            return false;

        }

        bool F()
        {


            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST")
            {

                if (CONST())
                {

                    return true;

                }
            }
            else if (ts[index][0] == "(")
            {

                index++;
                if (OE())
                {
                    if (ts[index][0] == ")")
                    {
                        return true;
                    }
                }

            }
            else if (ts[index][0] == "!")
            {
                index++;
                if (F())
                {
                    return true;
                }
            }
            else if (ts[index][0] == "INC_DEC")
            {
                index++;

                if (ts[index][0] == "ID")
                {

                    index++;

                    if (X())
                    {
                        return true;
                    }
                }

            }
            else
            {
                if (ts[index][0] == "ID")
                {


                    index++;

                    if (F2())
                    {

                        return true;
                    }
                }

            }
            return false;
        }


        bool F2() //SELECTION(<F2>)= {. ,MDM , PM ,ROP , &&  , ||  ,  ;  ,  )  ,  ]   ,  DT ,     ,}

        {

            if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == "," || ts[index][0] == "||" || ts[index][0] == "&&" || ts[index][0] == "ROP" || ts[index][0] == "PM" || ts[index][0] == "MDM" || ts[index][0] == ".")
            {


                if (X())
                {

                    if (F3())
                    {

                        return true;

                    }

                }
            }



            return false;



        }


        bool F3()
        {


            if (ts[index][0] == "INC_DEC")
            {
                index++;
                return true;
            }
            else if (ts[index][0] == "(")
            {
                index++;
                if (PL())
                {

                    if (ts[index][0] == ")")
                    {
                        if (ts[index][0] == ";")
                        {


                            return true;

                        }




                    }

                }

            }//FOLLOW(<F3>)=  {MDM , PM ,ROP , &&  , ||  ,  ;  ,  )  ,  ]   ,  DT ,     ,}
            else
            {
                if (ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == "," || ts[index][0] == "||" || ts[index][0] == "&&" || ts[index][0] == "ROP" || ts[index][0] == "PM" || ts[index][0] == "MDM" )
                {

                    return true;
                }
            }


            return false;

    
        }



        bool X()
        {


            if (ts[index][0] == ".")
            {

                if (X2())
                {
                    return true;
                }
            }//  FOLLOW(<X>)={MDM , PM , ROP ,&& ,  || ,  ;  ,  ) , ] ,DT ,  ,  , (  , INC_DEC, =,COMP_ASSGN , INT_CONST ,STRING_CONST , CHAR_C0NST , FLOAT_CONST ,BOOLEAN_CONST , !  , ID}

            else
            {
                if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST"
                    || ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == ","
                    || ts[index][0] == "||" || ts[index][0] == "&&" || ts[index][0] == "ROP" || ts[index][0] == "PM" || ts[index][0] == "MDM"
                    || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "=" || ts[index][0] == "COMP_ASSGN" || ts[index][0] == "||"
                    || ts[index][0] == "ID" || ts[index][0] == "!")
                {

                    return true;
                }
            }
            return false;
        }

        bool X2()
        {

            if (ts[index][0] == "ID")
            {

                index++;
                if (X())
                {
                    return true;

                }

            }
            else if (ts[index][0] == "[")
            {
                index++;
                if (OE())
                {
                    if (ts[index][0] == "]")
                    {
                        if (OE())
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (ts[index][0] == "(")
                {
                    if (PL())
                    {
                        if (ts[index][0] == ")")
                        {
                            if (ts[index][0] == ".")
                            {
                                if (ts[index][0] == "ID")
                                {
                                    if (X3())
                                    {

                                        return true;
                                    }
                                }
                            }
                        }
                    }

                }
            }


            return false;

        }

        bool X3()
        {

            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST"
                   || ts[index][0] == ";" || ts[index][0] == ")" || ts[index][0] == "]" || ts[index][0] == "DT" || ts[index][0] == ","
                   || ts[index][0] == "||" || ts[index][0] == "&&" || ts[index][0] == "ROP" || ts[index][0] == "PM" || ts[index][0] == "MDM"
                   || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "=" || ts[index][0] == "COMP_ASSGN" || ts[index][0] == "||"
                   || ts[index][0] == "ID" || ts[index][0] == "!" || ts[index][0] == ".")
            {
                if (X())
                {
                    return true;
                }

            
            }
            else
            {
                if (ts[index][0] == "[")
                {
                    if (OE())
                    {
                        if (ts[index][0] == "]")
                        {

                            if (OE())
                            {

                                return true;
                            }
                        }

                    }

                }
            }

            return false;


            }


         bool PL()
        {

            if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
            {

                if (OE())
                {
                    if (PL2())
                    {
                        return true;

                    }

                }


            }
            else
            {

                if (ts[index][0] == ")")
                {

                    return true;
                }

            }
            return false;


         }

        bool PL2()
        {
            if (ts[index][0] == ",")
            {
                index++;
                if (OE())
                {
                    if (PL())
                    {
                        return true;
                    }

                }

              
            }
            else
            {

                if (ts[index][0] == ")")
                {

                    return true;
                }
            }

            return false;


        }

        bool CONST()
        {
            if (ts[index][0] == "INT_CONST")
            {
                index++;
                return true;

            }
            else if (ts[index][0] == "STRING_CONST")
            {
                index++;
                return true;
            }
            else if (ts[index][0] == "FLOAT_CONST")
            {
                index++;
                return true;
            }
            else if (ts[index][0] == "BOOLEAN_CONST")
            {
                index++;
                return true;

            }
            else if (ts[index][0] == "CHAR_CONST")
                {
                index++;
                return true;

            }
            return false;
            }


      //  FIRST(<SST>)={DT, if,ACC_MOD ,do,while, for, switch , INC_DEC , ID , try  ,  List
    

    bool SST()
    {
        if (


             ts[index][0] == "ID")

        {
            index++;
            if (A())
            {
                return true;
            }

        }
        else if (ts[index][0] == "DT")
        {
            if (DEC())
            {
                return true;
            }

        }
        else if (ts[index][0] == "if")
        {
            if (IF_ELSE())
            {
                return true;
            }
        }
            else if (ts[index][0] == "ACC_MOD")
            {
                if (FUNC_ST())
                {
                    return true;
                }
            }
            else if (ts[index][0] == "do")
        {
            if (DO_WHILE())
            {
                return true;
            }
        }
        else if (ts[index][0] == "while")
        {

                if (WHILE_ST())
            {
                return true;
            }
        }
        else if (ts[index][0] == "for")
        {
                
            if (FOR_ST())
            {

                    return true;
            }
        }


        else if (ts[index][0] == "switch")
        {
            if (SWITCH_ST())
            {

                    return true;
            }
        }
        else if (ts[index][0] == "INC_DEC")
        {
            index++;
            if (ts[index][0] == "ID")
            {
                index++;
                if (X())
                {
                        if (ts[index][0] == ";")
                        {

                            index++;
                            return true;


                        }

                        
                }
            }
        }
        else if (ts[index][0] == "try")
        {
            if (EXCEPTION())
            {
                return true;
            }

        }
        else if (ts[index][0] == "List")
        {
            if (LIST_ST())
            {
                return true;
            }
        }



        return false;



    }
    //FIRST(<A>)= { = ,COMP_ASSGN ,INC_DEC ,  (  ,   .  , ID  }

    bool A()
    {
        if (ts[index][0] == "=" || ts[index][0] == "COMP_ASSGN" || ts[index][0] == "INC_DEC" || ts[index][0] == "("
            || ts[index][0] == "." || ts[index][0] == "ID")
        {
            if (X())
            {
                if (A2())
                {
                    return true;

                }

            }

        }
        else if (ts[index][0] == "ID")
        {
            index++;
            if (A1())
            {
                return true;
            }
        }

        return false;
    }
    bool A1()
    {
        if (ts[index][0] == "=")
        {
            index++;
            if (ts[index][0] == "new")
            {
                index++;
                if (ts[index][0] == "ID")
                {
                    index++;
                    if (ts[index][0] == "(")
                    {
                        index++;
                        if (PL())
                        {
                            if (ts[index][0] == ")")
                            {
                                index++;

                                if (ts[index][0] == ";")
                                {
                                    index++;
                                    return true;

                                }

                            }
                        }
                    }
                }
            }



        }
        else if (ts[index][0] == ";")
        {
            index++;
            return true;

        }


        return false;
    }




    bool A2()
    {

        if (ts[index][0] == "COMP_ASSGN" || ts[index][0] == "=")
        {
            if (ASSIGN_OP())
            {
                if (OE())
                {
                    if (ts[index][0] == ";")
                    {
                        index++;
                        return true;

                    }


                }

            }

        }
        else if (ts[index][0] == "INC_DEC")
        {

            index++;
            if (ts[index][0] == ";")
            {
                    index++;
                return true;
            }


        }

        else if (ts[index][0] == "(")
        {
            index++;
            if (PL())
            {

                if (ts[index][0] == ")")
                {
                    index++;
                    if (ts[index][0] == ";")
                    {
                            index++;
                        return true;
                    }
                }


            }

        }

        return false;
    }

    //FIRST(<MST>)={DT, if,ACC_MOD ,do,while, for, switch , INC_DEC , ID , try  ,  List}
    bool MST()
    {

            if (ts[index][0] == "DT" || ts[index][0] == "if" || ts[index][0] == "ACC_MOD" || ts[index][0] == "do"
            || ts[index][0] == "while" || ts[index][0] == "for" || ts[index][0] == "switch" || ts[index][0] == "INC_DEC"
            || ts[index][0] == "ID" || ts[index][0] == "try" || ts[index][0] == "List")
        {
                if (SST())
                {

                    if (MST())
                    {
                        return true;

                    }
                }

        }

        else if (ts[index][0] == "}" || ts[index][0] == "return")
        {
            return true;
        }

        return false;

    }


    bool BODY()
    {
        if (ts[index][0] == "DT" || ts[index][0] == "if" || ts[index][0] == "ACC_MOD" || ts[index][0] == "do"
            || ts[index][0] == "while" || ts[index][0] == "for" || ts[index][0] == "switch" || ts[index][0] == "INC_DEC"
            || ts[index][0] == "ID" || ts[index][0] == "try" || ts[index][0] == "List" || ts[index][0] == "}" || ts[index][0] == "return")
        {
            if (MST())
            {

                    return true;


            }

        }



            return false;

    }


    bool FOR_ST()
    {

        if (ts[index][0] == "for")
        {
            index++;

                if (ts[index][0] == "(")
            {
                index++;
                if (C1())
                {

                        if (C2())
                    {
                        if (ts[index][0] == ";")
                        {
                                index++;
                            if (C3())
                            {
                                if (ts[index][0] == ")")
                                {
                                        index++;
                                    if (ts[index][0] == "then")
                                    {
                                            index++;

                                            if (ts[index][0] == "{")
                                        {
                                                index++;


                                                if (BODY())
                                            {
                                                if (ts[index][0] == "}")
                                                {
                                                        index++;


                                                        return true;
                                                }

                                            }

                                        }
                                    }

                                }

                            }

                        }
                    }

                }

            }



        }

        return false;




    }

    bool C1()
    {

        if (ts[index][0] == "DT")
        {


                if (DEC())
            {

                    return true;
            }

        }
        else if (ts[index][0] == "ID")
        {
            if (ASSIGN_ST())
            {
                return true;


            }

        }
        else if (ts[index][0] == ";")
        {
            index++;
            return true;
        }

        return false;
    }


    bool C2()
    {
        if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST" || ts[index][0] == "(" || ts[index][0] == "INC_DEC" || ts[index][0] == "ID" || ts[index][0] == "!")
        {

            if (OE())
            {
                return true;

            }

        }
        else if (ts[index][0] == ";")
        {

            return true;
        }

        return false;

    }

    bool C3()
    {

        if (ts[index][0] == "ID")
        {

            index++;
            if (X())
            {
                if (C4())
                {

                    return true;
                }
            }
        }
        else if (ts[index][0] == "INC_DEC")
        {
            index++;
            if (ts[index][0] == "ID")
            {
                index++;
                if (X())
                {
                    return true;
                }
            }

        }
        else if (ts[index][0] == ")")
        {
            return true;

        }


        return false;
    }




        bool C4()
        {


            if (ts[index][0] == "=" || ts[index][0] == "COMP_ASSGN")
            {
                if (ASSIGN_OP())
                {
                    if (OE())
                    {
                        return true;

                    }
                }

            }
            else if (ts[index][0] == "INC_DEC")
            {
                index++;
                return true;

            }

            return false;

        }


        bool DEC()
        {
            if (ts[index][0] == "DT")
            {
                index++;

                if (ts[index][0] == "ID")
                {
                    index++;
                    if (INIT())
                    {
                        if (DEC2())
                        {
                            return true;
                        }
                    }
                }


            }

            return false;

        }

        bool DEC2()
        {
            if (ts[index][0] == ";")
            {
                index++;
                return true;



            }
            else if (ts[index][0] == ",")
            {
                index++;
                if (ts[index][0] == "ID")
                {
                    index++;
                    if (INIT())
                    {
                        if (DEC2())
                        {
                            return true;
                        }

                    }
                }


            }
            return false;


        }


        bool INIT()
        {
            if (ts[index][0] == "=")
            {
                index++;
                if (OE())
                {
                    return true;
                }

            }
            else if (ts[index][0] == "DT"|| ts[index][0] == ";" || ts[index][0] == ",")
            {

                return true;
         
            }

            return false;
        }



        bool WHILE_ST()
        {

            if (ts[index][0] == "while")
            {

                index++;

                if (ts[index][0] == "(")
                {

                    index++;

                    if (OE())
                    {

                        if (ts[index][0] == ")")
                        {
                            index++;
                            if (ts[index][0] == "then")
                            {
                                index++;
                                if (ts[index][0] == "{")
                                {
                                    index++;
                                    if (BODY())
                                    {

                                        if (ts[index][0] == "}")
                                        {

                                            index++;
                                            return true;
                                        }
                                    }
                                }
                            }

                        }

                    }
                }

            }
            return false;

        }


        bool DO_WHILE()
        {

            if (ts[index][0] == "do")
            {
                index++;
                if (ts[index][0] == "{")
                {
                    index++;

                    if (BODY())
                    {
                        if (ts[index][0] == "}")
                        {
                            index++;


                            if (ts[index][0] == "while")
                            {
                                index++;

                                if (ts[index][0] == "(")
                                {
                                    index++;

                                    if (OE())
                                    {
                                        if (ts[index][0] == ")")
                                        {
                                            index++;

                                            if (ts[index][0] == ";")
                                            {
                                                index++;
                                                return true;
                                            }
                                        }

                                    }

                                }

                            }
                        }

                    }

                }
            }


            return false;

        }


        bool SWITCH_ST()
        {
            if (ts[index][0] == "switch")
            {
                index++;
                if (ts[index][0] == "(")
                {
                    index++;
                    if (OE())
                    {

                        if (ts[index][0] == ")")
                        {
                            index++;

                            if (ts[index][0] == "{")
                            {
                                index++;

                                if (CASES())
                                {

                                    if (ts[index][0] == "}")
                                    {
                                        index++;
                                        return true;
                                    }


                                }
                            }

                        }

                    }

                }

         
            }

            return false;
        }

        bool CASES()
        {
            if (ts[index][0] == "case")
            {
                index++;
                if (CONST())
                {

                    if (ts[index][0] == ":")
                    {
                        index++;
                        if (ts[index][0] == "{")
                        {
                            index++;
                            if (BODY())
                            {

                                if (ts[index][0] == "}")
                                {
                                    index++;

                                    if (ts[index][0] == "break")
                                    {
                                        index++;
                                        if (ts[index][0] == ";")
                                        {

                                            index++;

                                            if (CASES())
                                            {
                                                return true;
                                            }

                                        }
                                    }


                                }

                            }
                        }

                    }

                }

            }
            else if (ts[index][0] == "default")
            {
                index++;
                if (ts[index][0] == ":")
                {

                    index++;
                    if (ts[index][0] == "{")
                    {

                        index++;
                        if (BODY())
                        {

                            if (ts[index][0] == "}")
                            {
                                index++;

                                if (ts[index][0] == "break")
                                {

                                    index++;
                                    if (ts[index][0] == ";")
                                    {
                                        index++;
                                        return true;

                                    }
                                }


                            }

                        }
                    }

                }

            }
            else if (ts[index][0] == "}")
            {
                return true;

            }




            return false;
        }



        bool LIST_ST()
        {
            if (ts[index][0] == "List")
            {
                index++;
                if (DT_TYPE())
                {

                    if (ts[index][0] == "ID")
                    {
                        index++;

                        if (S())
                        {
                            if (ts[index][0] == ";")
                            {
                                index++;
                                return true;

                            }

                        }
                    }
                }


            }

            return false;
        }

        bool S()
        {
            if (ts[index][0] == "=")
            {
                index++;
                if (ts[index][0] == "new")
                {
                    index++;

                    if (ts[index][0] == "List")
                    {
                        index++;

                        if (ts[index][0] == "(")
                        {
                            index++;
                            if (ts[index][0] == ")")
                            {
                                index++;
                                return true;

                            }

                        }
                    }

                }
            }
            else if (ts[index][0] == ";")
            {
                return true;

            }

            return false;



        }

        bool DT_TYPE()
        {

            if (ts[index][0] == "ID")
            {

                index++;
                return true;
            }
            else if (ts[index][0] == "DT")
            {
                index ++;

                return true;
            }

            return false;
        }


        bool IF_ELSE()
        {
            if (ts[index][0] == "if")
            {
                index++;
                if (ts[index][0] == "(")
                {
                    index++;
                    if (OE())
                    {
                        if (ts[index][0] == ")")
                        {
                            index++;

                            if (ts[index][0] == "then")
                            {
                                index++;

                                if (ts[index][0] == "{")
                                {
                                    index++;
                                    if (BODY())
                                    {

                                        if (ts[index][0] == "}")
                                        {
                                            index++;
                                            if (OELSE())
                                            {

                                                return true;
                                            }

                                        }

                                    }

                                }


                            }

                        }

                    }

                }

            }

            return false;
        }



        bool OELSE()
        {

            if (ts[index][0] == "else")
            {
                index++;
                if (ts[index][0] == "{")
                {
                    index++;
                    if (BODY())
                    {
                        if (ts[index][0] == "}")
                        {
                            index++;
                            return true;

                        }

                    }

                }


            }
          else  if (ts[index][0] == "DT" || ts[index][0] == "if" || ts[index][0] == "ACC_MOD" || ts[index][0] == "do"
             || ts[index][0] == "while" || ts[index][0] == "for" || ts[index][0] == "switch" || ts[index][0] == "INC_DEC"
             || ts[index][0] == "ID" || ts[index][0] == "try" || ts[index][0] == "List" || ts[index][0] == "return" || ts[index][0] == "}")
            {


                return true;


            }


            return false;
        }

        bool EXCEPTION()
        {
            if (ts[index][0] == "try")
            {
                index++;
                if (ts[index][0] == "{")
                {

                    index++;
                    if (BODY())
                    {
                        if (ts[index][0] == "}")
                        {

                            index++;

                            if (ts[index][0] == "catch")
                            {
                                index++;

                                if (ts[index][0] == "{")
                                {

                                    index++;
                                    if (BODY())
                                    {
                                        if (ts[index][0] == "}")
                                        {

                                            index++;

                                            if (ts[index][0] == "finally")
                                            {
                                                index++;
                                                if (ts[index][0] == "{")
                                                {

                                                    index++;
                                                    if (BODY())
                                                    {
                                                        if (ts[index][0] == "}")
                                                        {

                                                            index++;

                                                            return true;
                                                           
                                                        }

                                                    }
                                                }

                                            }
                                        }

                                    }
                                }
                            }
                        }

                    }
                }

            }

            return false;

        }


        bool ASSIGN_ST()
        {

            if (ts[index][0] == "ID")
            {
                index++;
                if (X())
                {

                    if (ASSIGN_OP())
                    {

                        if (OE())
                        {
                            if (ts[index][0] == ";")
                            {
                                index++;
                                return true;
                            }

                        }
                    }
                }

            }
            return false;
        }

        bool ASSIGN_OP()
        {
            if (ts[index][0] == "=")
            {
                index++;


                return true;
            }
           else if (ts[index][0] == "COMP_ASSGN")
            {

                index++;
                return true;

            }

            return false;
        }



        bool FUNC_ST()
        {
            if (ts[index][0] == "ACC_MOD")
            {
                index++;
                if (OVERRIDING())
                {
                    if (RETURN_TYPE())
                    {
                        if (ts[index][0] == "ID")
                        {
                            index++;

                            if (ts[index][0] == "(")
                            {
                                index++;
                                if (ARG())
                                {
                                    if (ts[index][0] == ")")
                                    {
                                        index++;
                                        if (ts[index][0] == "{")
                                        {
                                            index++;
                                            if (BODY())
                                            {

                                                if (RETURN_ST())
                                                {

                                                    if (ts[index][0] == "}")
                                                    {
                                                        index++;

                                                        return true;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                        }

                    }

                }

            }

            return false;
        }

        bool RETURN_TYPE()
        {
            if (ts[index][0] == "DT"|| ts[index][0] == "List"|| ts[index][0] == "ID")
            {

                if (TYPE())
                {
                    return true;

                }
            }
            else if (ts[index][0] == "void")
            {
                index++;
                return true;

            }

            return false;
        }

        bool RETURN_ST()
        {
            if (ts[index][0] == "return")
            {
                index++;
                if (VALUES())
                {

                    if (ts[index][0] == ";")
                    {

                        index++;
                        return true;
                    }
                }

            }
            else if (ts[index][0] == "}")
            {

                return true;
            }


            return false;
        }
        bool VALUES()
        {

            if (ts[index][0] == "ID")
            {
                index++;
                if (VALUES2())
                {
                    return true;

                }


            }
           else if (ts[index][0] == "INT_CONST" || ts[index][0] == "STRING_CONST" || ts[index][0] == "CHAR_C0NST" || ts[index][0] == "FLOAT_CONST" || ts[index][0] == "BOOLEAN_CONST")
            {

                if (CONST())
                {

                    return true;

                }
            }
            else if (ts[index][0] == ";")
            {

                return true;
            }

            return false;
        }

       bool VALUES2()
        {

            if (ts[index][0] == "[")
            {
                index++;
                if (OE())
                {

                    if (ts[index][0] == "]")
                    {
                        index++;
                        return true;
                    }
                }

            }
            else if (ts[index][0] == "."|| ts[index][0] == ";")
            {

                if (X())
                {
                    return true;

                }
            }
            else if (ts[index][0] == ";")
            {
                return true;
            }


            return false;
        }


        bool TYPE()
        {

            if (ts[index][0] == "ID")
            {
                index++;

                return true;
            }
            else if (ts[index][0] == "DT")
            {

                index++;
                return true;
            }
            else
            if (ts[index][0] == "List")
            {
                index++;

                if (DT_TYPE())
                {

                    return true;
                }
            }
            return false ;

        }


        bool OVERRIDING()
        {

            if (ts[index][0] == "override")
            {
                index++;

                return true;

            }
            else if (ts[index][0] == "DT" || ts[index][0] == "List" || ts[index][0] == "ID" || ts[index][0] == "void")
            {
                return true;
            }

            return false;

        }

        bool ARG()
        {
            if (ts[index][0] == "DT" || ts[index][0] == "List" || ts[index][0] == "ID")
            {
                if (TYPE())
                {
                    if (ts[index][0] == "ID")
                    {
                        index++;
                        if (ARG2())
                        {

                            return true;
                        }
                    }

                }
            }
            else if (ts[index][0] == ")")
            {
                return true;

            }

            return false;
        }

        bool ARG2()
        {

            if (ts[index][0] == ",")
            {
                index++;
                if (TYPE())
                {
                    if (ts[index][0] == "ID")
                    {
                        index++;
                        if (ARG2())
                        {
                            return true;

                        }
                    }

                }
            }
            else if (ts[index][0] == ")")
            {
                return true;

            }

            return false;


        }


        //FIRST(<SST1>)={ACC_MOD , DT , ID , INC_DEC , List}

        bool SST1()
        {
            if (


                 ts[index][0] == "ID")

            {
                index++;
                if (A())
                {
                    return true;
                }

            }
            else if (ts[index][0] == "DT")
            {
                if (DEC())
                {
                    return true;
                }

            }
         
            else if (ts[index][0] == "ACC_MOD")
            {
                if (A3())
                {
                    return true;
                }
            }
            
            else if (ts[index][0] == "INC_DEC")
            {
                index++;
                if (ts[index][0] == "ID")
                {
                    index++;
                    if (X())
                    {
                        if (ts[index][0] == ";")
                        {

                            index++;
                            return true;


                        }

                    }
                }
            }
           
            else if (ts[index][0] == "List")
            {
                if (LIST_ST())
                {
                    return true;
                }
            }



            return false;



        }


        bool A3()
        {
            if (ts[index][0] == "DT" || ts[index][0] == "List" || ts[index][0] == "ID" || ts[index][0] == "void"|| ts[index][0] == "override")
            {
                if (OVERRIDING())
                {
                    if (RETURN_TYPE())
                    {
                        if (ts[index][0] == "ID")
                        {
                            index++;
                            if (ts[index][0] == "(")
                            {
                                index++;
                                if (ARG())
                                {

                                    if (ts[index][0] == ")")
                                    {
                                        index++;

                                        if (ts[index][0] == "{")
                                        {

                                            index++;
                                            if (BODY())
                                            {

                                                if (RETURN_ST())
                                                {

                                                    if (ts[index][0] == "}")
                                                    {

                                                        index++;

                                                        return true;
                                                    }
                                                }
                                            }

                                        }
                                    }
                                }

                            }

                        }

                    }

                }
            }
            else if (ts[index][0] == "ABSTRACTION"|| ts[index][0] == "INTERFACE"|| ts[index][0] == "class")
            {

                if (IN_AB())
                {
                    if (ts[index][0] == "class")
                    {
                        index++;
                        if (ts[index][0] == "ID")
                        {
                            index++;
                            if (OPTION())
                            {
                                if (ts[index][0] == "then")
                                {
                                    index++;
                                    if (ts[index][0] == "{")
                                    {
                                        index++;

                                        if (CTOR())
                                        {

                                            if (BODY1())
                                            {

                                                if (ts[index][0] == "}")
                                                {

                                                    index++;

                                                    return true;
                                                }
                                            }
                                        }
                                    }

                                }

                            }

                        }

                    }

                }


            }


            return false;
        }



        bool OPTION()
        {
            if (ts[index][0] == "INHERITANCE")
            {
                index++;
                if (ts[index][0] == "ID")
                {
                    index++;

                    return true;

                }

            }
            else if (ts[index][0] == "INTERFACE")
            {

                index++;
                if (ts[index][0] == "ID")
                {

                    index++;
                    return true;
                }
            }

            else if (ts[index][0] == "then")
            {

                return true;

            }


            return false;
        }


        bool IN_AB()
        {
            if (ts[index][0] == "INTERFACE")
            {
                index++;

                return true;
            }
            else if(ts[index][0] == "ABSTRACTION")
            {
                index++;

                return true;
                
            }
            else if (ts[index][0] == "class")
            {

                return true;

            }

            return false;

        }

        bool CTOR()
        {

            if (ts[index][0] == "ACC_MOD")
            {

                index++;

                if (ts[index][0] == "ID")
                {

                    if (ts[index][0] == "(")
                    {

                        index++;
                        if (ARG())
                        {

                            if (ts[index][0] == ")")
                            {
                                index++;
                                if (ts[index][0] == "{")
                                {
                                    index++;
                                    if (BODY())
                                    {

                                        if (ts[index][0] == "}")
                                        {

                                            index++;
                                            return true;
                                        }
                                    }

                                }

                            }


                        }
                        


                    }

                }

                //FOLLOW(<CTOR>)=FIRST(BODY1)={ACC_MOD , DT , ID , INC_DEC ,  }  }




            }
            else if (ts[index][0] == "ACC_MOD" || ts[index][0] == "DT" || ts[index][0] == "ID" || ts[index][0] == "INC_DEC" || ts[index][0] == "}")
            {
                return true;
            }




            return false;

        }





        bool MST1()
        {

            if (ts[index][0] == "DT"  || ts[index][0] == "ACC_MOD" 
                    ||ts[index][0] == "INC_DEC"
            || ts[index][0] == "ID"  || ts[index][0] == "List")
            {
                if (SST1())
                {

                    if (MST1())
                    {
                        return true;

                    }
                }

            }

            else if (ts[index][0] == "}" || ts[index][0] == "void")
            {
                return true;
            }

            return false;

        }



        bool BODY1()
        {


            if (ts[index][0] == "DT" || ts[index][0] == "ACC_MOD"
                  || ts[index][0] == "INC_DEC"
          || ts[index][0] == "ID" || ts[index][0] == "List"|| ts[index][0] == "}" || ts[index][0] == "void")
            {
              

                    if (MST1())
                    {
                        return true;

                    }
                

            }

          

            return false;


        }











    }
}
