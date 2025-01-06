import pandas as pd
import matplotlib.pyplot as plt
#from datetime import date

def analyze_excel(file_path):
    # Charger le fichier Excel
    excel_data = pd.ExcelFile(file_path)
    report = []

    print(f"Analyse du fichier : {file_path}")
    print("=" * 50)

    # Parcourir les feuilles spécifiques
    #sheets_to_analyze = ["commande livrer en 2024", "commande livrer en 2023", "toutes les commandes 2024"]
    
    for sheet_name in excel_data.sheet_names :
        print(f"Analyse de la feuille : {sheet_name}")
        print("-" * 50)
        try:
            data = pd.read_excel(file_path, sheet_name=sheet_name)

            # Vérifier les colonnes disponibles
            print(f"Colonnes trouvées : {data.columns.tolist()}")
            print(f"Nombre total de lignes : {len(data)}")

            recommendations = []

            # Analyse Date
            if 'Date' in data.columns:
                data['Date'] = pd.to_datetime(data['Date'], errors='coerce',  dayfirst = True)
                if data['Date'].notna().all():
                    monthly_totals = data.groupby(data['Date'].dt.month)['Sous total'].sum()
                    monthly_totals.plot(kind='bar', title=f'CA Mensuel - {sheet_name}', xlabel='Mois', ylabel='Sous total (CA)')
                    plt.savefig(f'ca_mensuel_{sheet_name}.png')
                    plt.close()
                    recommendations.append(f"Examinez les pics mensuels de CA dans {sheet_name} pour planifier des campagnes adaptées (voir graphique).")

            # Analyse Agent
            if 'Agent' in data.columns:
                agent_performance = data.groupby('Agent')['Sous total'].sum().sort_values(ascending=False)
                agent_performance.plot(kind='bar', title=f'Performance des Agents - {sheet_name}', xlabel='Agent', ylabel='Sous total (CA)')
                plt.savefig(f'performance_agents_{sheet_name}.png')
                plt.close()
                recommendations.append(f"Identifiez les agents performants pour partager leurs pratiques et renforcer les moins performants dans {sheet_name}.")

            # Analyse Type de vendeur
            if 'Type de vendeur' in data.columns:
                seller_type_performance = data.groupby('Type de vendeur')['Sous total'].sum()
                seller_type_performance.plot(kind='pie', autopct='%1.1f%%', title=f'Repartition par Type de Vendeur - {sheet_name}')
                plt.savefig(f'repartition_vendeur_{sheet_name}.png')
                plt.close()
                recommendations.append(f"Adaptez les formations aux performances des différents types de vendeurs dans {sheet_name} (voir graphique).")

            # Analyse Annonce
            if 'Annonce' in data.columns:
                annonce_performance = data.groupby('Annonce')['Sous total'].sum().sort_values(ascending=False)
                annonce_performance.plot(kind='bar', title=f'Performance des Annonces - {sheet_name}', xlabel='Annonce', ylabel='Sous total (CA)')
                plt.savefig(f'performance_annonces_{sheet_name}.png')
                plt.close()
                recommendations.append(f"Optimisez vos campagnes en analysant les annonces les plus performantes dans {sheet_name}.")

            # Analyse Statut
            if 'Statut' in data.columns:
                statut_counts = data['Statut'].value_counts()
                statut_counts.plot(kind='bar', title=f'Statuts des Commandes - {sheet_name}', xlabel='Statut', ylabel='Nombre')
                plt.savefig(f'statuts_commandes_{sheet_name}.png')
                plt.close()
                recommendations.append(f"Réduisez les commandes annulées ou en attente dans {sheet_name} pour minimiser les pertes.")

            # Analyse Fournisseur et Catégorie
            if 'Fournisseur' in data.columns and 'Catégorie' in data.columns:
                fournisseur_performance = data.groupby(['Fournisseur', 'Catégorie'])['Sous total'].sum().unstack()
                fournisseur_performance.plot(kind='bar', title=f'Performance Fournisseurs/Catégories - {sheet_name}')
                plt.savefig(f'fournisseur_categorie_{sheet_name}.png')
                plt.close()
                recommendations.append(f"Identifiez les fournisseurs et catégories clés pour optimiser votre offre dans {sheet_name}.")

            # Analyse Quantité et Profit Cowema
            if 'Quantité' in data.columns and 'Profit Cowema' in data.columns:
                data.plot(kind='scatter', x='Quantité', y='Profit Cowema', title=f'Quantité vs Profit - {sheet_name}')
                plt.savefig(f'quantite_profit_{sheet_name}.png')
                plt.close()
                recommendations.append(f"Analysez la relation entre les quantités vendues et le profit pour optimiser les volumes dans {sheet_name}.")

            # Génération de recommandations
            print("\nRecommandations :")
            for rec in recommendations:
                print(f"- {rec}")
                report.append(f"[{sheet_name}] {rec}")

            print("=" * 50)
        except Exception as e:
            print(f"Erreur lors de l'analyse de la feuille {sheet_name} : {e}")
            print("=" * 50)

    # Génération du rapport
    with open("rapport_analyse.txt", "w") as file:
        file.write("Rapport d'Analyse\n")
        file.write("=" * 50 + "\n")
        for rec in report:
            file.write(rec + "\n")
    print("Analyse terminée. Rapport enregistré sous 'rapport_analyse.txt'.")

# Exemple d'utilisation
file_path = 'C:/Users/Master/Downloads/commandes.xlsx'  # Remplacez par le chemin de votre fichier
analyze_excel(file_path)

